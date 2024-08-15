using Assets.Scripts.Voters;
using Assets.Scripts.Policies;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Assets.Scripts.UI
{
	internal class VotingScreen : MonoBehaviour
	{
		[SerializeField] private GameObject votersListRoot;
		[SerializeField] private VoterButton stubVoterButton;
		[SerializeField] private GameObject policyButtonsListRoot;
		[SerializeField] private GameObject stubPolicyButton;
		[SerializeField] private TextMeshPro opinionLabel;

		private List<Policy> policies = new();
		private List<Voter> voters = new();
		private List<PolicyButton> policyButtons = new();
		private List<VoterButton> voterButtons = new();

		private Policy pickedPolicy = null;

		private void Awake()
		{
			CreateVoters();
			CreatePolicies();
			BuildVotersList();
			BuildPolicyButtonsList();
		}

		private void CreateVoters()
		{
			this.voters.Add(new Carrot());
			this.voters.Add(new Rabbit());
			this.voters.Add(new Wolf());
		}

		private void CreatePolicies()
		{
			this.policies.Add(new DestroyAllCarrots());
			this.policies.Add(new ForceRabbitsToWaterCarrots());
			this.policies.Add(new ForceWolvesToWaterCarrots());
			this.policies.Add(new KillAllRabbits());
			this.policies.Add(new KillAllWolves());
			this.policies.Add(new ProhibitEatingCarrots());
			this.policies.Add(new ProhibitEatingRabbits());
		}

		private void RestartElections()
		{
			this.pickedPolicy = null;
			this.opinionLabel.text = string.Empty;
		}

		private void BuildVotersList()
		{
			this.stubVoterButton.gameObject.SetActive(false);
			foreach (Voter voter in this.voters)
			{
				AddButtonForVoter(voter);
			}
		}

		private void AddButtonForVoter(Voter voter)
		{
			VoterButton b = Instantiate(this.stubVoterButton.gameObject, this.votersListRoot.transform).GetComponent<VoterButton>();
			b.gameObject.SetActive(true);
			b.name = voter.GetType().Name;
			b.GetComponentInChildren<TextMeshPro>().text = voter.Name;
			this.voterButtons.Add(b);
			b.onClick.AddListener(() =>
			{
				this.opinionLabel.text = $"{voter.Name}'s opinion: {voter.GetOpinion()}";
			});
		}

		private void BuildPolicyButtonsList()
		{
			this.stubPolicyButton.gameObject.SetActive(false);
			foreach (Policy policy in this.policies)
			{
				AddButtonForPolicy(policy);
			}
		}

		private void AddButtonForPolicy(Policy policy)
		{
			PolicyButton b = Instantiate(this.stubPolicyButton.gameObject, this.policyButtonsListRoot.transform).GetComponent<PolicyButton>();
			b.gameObject.SetActive(true);
			b.name = policy.GetType().Name;
			b.GetComponentInChildren<TextMeshPro>().text = policy.Name;
			this.policyButtons.Add(b);
			b.onClick.AddListener(() =>
			{
				OnPolicyPicked(policy);
			});
		}

		private void OnPolicyPicked(Policy policy)
		{
			//TODO
		}
	}
}
