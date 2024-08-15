using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	[RequireComponent(typeof(Button))]
	internal class PolicyButton : MonoBehaviour
	{
		public Button Button { get; private set; }
		public Policy Policy { get; private set; }
		private void Awake()
		{
			this.Button = GetComponent<Button>();
		}
		public void BindTo(Policy policy)
		{
			this.Policy = policy;
		}
	}
}
