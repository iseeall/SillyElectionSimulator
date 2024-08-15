using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ForceWolvesToWaterCarrots : Policy
	{
		public override string Name => "Force wolves to water carrots!";
		public override float EvaluateBenefitFor(Carrot carrot) => 1f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => 0.2f;
		public override float EvaluateBenefitFor(Wolf wolf) => -0.8f;
	}
}
