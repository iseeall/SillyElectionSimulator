using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class DestroyAllCarrots : Policy
	{
		public override string Name => "Destroy all carrots!";
		public override float EvaluateBenefitFor(Carrot carrot) => -2f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => -1f;
		public override float EvaluateBenefitFor(Wolf wolf) => -0.1f;
	}
}
