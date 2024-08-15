using Assets.Scripts.Voters;
using Assets.Scripts.Policies;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Text;

namespace Assets.Scripts.UI
{
	internal class VotingScreen : MonoBehaviour
	{
		[SerializeField] private int minVoterPopulation = 10, maxVoterPopulation = 100;
		[SerializeField] private ScrollRect scrollRect;
		[SerializeField] private GameObject votersListRoot;
		[SerializeField] private VoterButton stubVoterButton;
		[SerializeField] private GameObject policyButtonsListRoot;
		[SerializeField] private GameObject stubPolicyButton;
		[SerializeField] private TextMeshProUGUI opinionLabel;
		[SerializeField] private TextMeshProUGUI pickedPolicyLabel;
		[SerializeField] private GameObject voteResultArea, voteResultExplanationArea;
		[SerializeField] private Button showResultExplanationButton, restartElectionButton;
		[SerializeField] private TextMeshProUGUI voteResultLabel, voteResultExplanationLabel;

		private readonly List<Policy> policies = new();
		private readonly List<Voter> voters = new();
		private readonly List<PolicyButton> policyButtons = new();
		private readonly List<VoterButton> voterButtons = new();

		private Policy pickedPolicy = null;
		private readonly Dictionary<Voter, PolicyReaction> reactions = new();

		private void Awake()
		{
			this.showResultExplanationButton.onClick.AddListener(ShowElectionResultExplanation);
			this.voteResultExplanationArea.gameObject.SetActive(false);
			this.restartElectionButton.onClick.AddListener(StartElection);
			StartElection();
		}

		private void CreateVoters()
		{
			this.voters.Clear();
			this.voters.Add(new Carrot(Random.Range(this.minVoterPopulation, this.maxVoterPopulation)));
			this.voters.Add(new Rabbit(Random.Range(this.minVoterPopulation, this.maxVoterPopulation)));
			this.voters.Add(new Wolf(Random.Range(this.minVoterPopulation, this.maxVoterPopulation)));
		}

		private void CreatePolicies()
		{
			this.policies.Clear();
			this.policies.Add(new DestroyAllCarrots());
			this.policies.Add(new ForceRabbitsToWaterCarrots());
			this.policies.Add(new ForceWolvesToWaterCarrots());
			this.policies.Add(new KillAllRabbits());
			this.policies.Add(new KillAllWolves());
			this.policies.Add(new ProhibitEatingCarrots());
			this.policies.Add(new ProhibitEatingRabbits());
		}

		private void StartElection()
		{
			CreateVoters();
			BuildVotersList();
			CreatePolicies();
			BuildPolicyButtonsList();
			this.pickedPolicy = null;
			this.reactions.Clear();
			this.pickedPolicyLabel.gameObject.SetActive(false);
			this.opinionLabel.text = string.Empty;
			this.voteResultArea.SetActive(false);
			this.voteResultExplanationArea.SetActive(false);
			Canvas.ForceUpdateCanvases();
			this.scrollRect.verticalNormalizedPosition = 1f;
		}

		private void BuildVotersList()
		{
			ClearVotersList();
			this.stubVoterButton.gameObject.SetActive(false);
			foreach (Voter voter in this.voters)
			{
				AddButtonForVoter(voter);
			}
		}

		private void ClearVotersList()
		{
			foreach (VoterButton b in this.voterButtons)
			{
				Destroy(b.gameObject);
			}
			this.voterButtons.Clear();
		}

		private void AddButtonForVoter(Voter voter)
		{
			VoterButton b = Instantiate(this.stubVoterButton.gameObject, this.votersListRoot.transform).GetComponent<VoterButton>();
			b.gameObject.SetActive(true);
			b.name = voter.GetType().Name;
			b.GetComponentInChildren<TextMeshProUGUI>().text = $"{voter.Name} ({voter.Population})";
			this.voterButtons.Add(b);
			b.Button.onClick.AddListener(() =>
			{
				this.opinionLabel.text = $"{voter.Name} (segment size = {voter.Population}):\n<i>{voter.GetOpinion()}</i>";
			});
		}

		private void BuildPolicyButtonsList()
		{
			ClearPolicyButtonsList();
			this.stubPolicyButton.gameObject.SetActive(false);
			foreach (Policy policy in this.policies)
			{
				AddButtonForPolicy(policy);
			}
		}

		private void ClearPolicyButtonsList()
		{
			foreach (PolicyButton b in this.policyButtons)
			{
				Destroy(b.gameObject);
			}
			this.policyButtons.Clear();
		}

		private void AddButtonForPolicy(Policy policy)
		{
			PolicyButton b = Instantiate(this.stubPolicyButton.gameObject, this.policyButtonsListRoot.transform).GetComponent<PolicyButton>();
			b.gameObject.SetActive(true);
			b.name = policy.GetType().Name;
			b.GetComponentInChildren<TextMeshProUGUI>().text = policy.Name;
			this.policyButtons.Add(b);
			b.Button.onClick.AddListener(() =>
			{
				OnPolicyPicked(policy);
			});
		}

		private void OnPolicyPicked(Policy policy)
		{
			this.pickedPolicy = policy;
			this.pickedPolicyLabel.gameObject.SetActive(true);
			this.pickedPolicyLabel.text = $"Picked policy: {policy.Name}";
			CalculatePickedPolicyReactions();
			bool hasWon = IsWinningElection();
			this.voteResultLabel.text = hasWon ? "You win the election!" : "You lost the election!";
			this.voteResultArea.gameObject.SetActive(true);
			Canvas.ForceUpdateCanvases();
			this.scrollRect.verticalNormalizedPosition = 0f;
		}

		private void CalculatePickedPolicyReactions()
		{
			this.reactions.Clear();
			foreach (Voter voter in this.voters)
			{
				PolicyReaction reaction = voter.GetReactionToPolicy(this.pickedPolicy);
				this.reactions[voter] = reaction;
			}
		}

		private bool IsWinningElection()
		{
			float weighedSumOfReactions = GetWeighedSumOfReactions();
			return weighedSumOfReactions > 0f;
		}

		private float GetWeighedSumOfReactions()
		{
			float weighedSumOfReactions = 0f;
			foreach (Voter voter in this.reactions.Keys)
			{
				float reaction = this.reactions[voter].Reaction;
				float weighedReaction = reaction * voter.Population;
				weighedSumOfReactions += weighedReaction;
			}
			return weighedSumOfReactions;
		}

		private void ShowElectionResultExplanation()
		{
			this.voteResultExplanationArea.SetActive(true);
			StringBuilder sb = new();
			sb.AppendLine($"Picked policy: {this.pickedPolicy.Name}");
			sb.AppendLine();
			foreach (Voter voter in this.reactions.Keys)
			{
				sb.AppendLine($"{voter.Name} vote:");
				PolicyReaction policyReaction = this.reactions[voter];
				sb.AppendLine($"{policyReaction.Explanation}");
				sb.AppendLine($"Reaction: {policyReaction.Reaction:0.#}");
				sb.AppendLine($"Segment size: {voter.Population}");
				sb.AppendLine($"Total weight: {(voter.Population * policyReaction.Reaction):0.#}");
				sb.AppendLine();
			}
			float weighedSum = GetWeighedSumOfReactions();
			sb.AppendLine($"Final score: {weighedSum:0.#}");
			sb.AppendLine("To win, you need final score to be positive.");
			this.voteResultExplanationLabel.text = sb.ToString();
			Canvas.ForceUpdateCanvases();
			this.scrollRect.verticalNormalizedPosition = 0f;
		}
	}
}
