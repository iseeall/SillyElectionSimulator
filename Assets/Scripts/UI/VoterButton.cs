using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	internal class VoterButton : Button
	{
		public Voter Voter { get; private set; }
		public void BindTo(Voter voter)
		{
			this.Voter = voter;
		}
	}
}
