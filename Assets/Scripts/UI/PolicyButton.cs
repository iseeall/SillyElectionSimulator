using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	internal class PolicyButton : Button
	{
		public Policy Policy { get; private set; }
		public void BindTo(Policy policy)
		{
			this.Policy = policy;
		}
	}
}
