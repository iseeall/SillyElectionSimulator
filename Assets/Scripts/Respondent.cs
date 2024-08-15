using UnityEngine;

namespace Assets.Scripts
{
	internal abstract class Respondent : MonoBehaviour
	{
		public abstract string Name { get; }
		public abstract string GetOpinion();

		public abstract bool WouldSupportPolicy(Policy policy);
	}
}
