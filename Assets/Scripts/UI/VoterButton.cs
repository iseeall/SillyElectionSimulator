using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	[RequireComponent(typeof(Button))]
	internal class VoterButton : MonoBehaviour
	{
		public Button Button { get; private set; }
		public Voter Voter { get; private set; }
		private void Awake()
		{
			this.Button = GetComponent<Button>();
		}
		public void BindTo(Voter voter)
		{
			this.Voter = voter;
		}
	}
}
