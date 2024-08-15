using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ForceRabbitsToWaterCarrots : Policy
	{
		public override string Name => "Force rabbits to water carrots!";
		public override float EvaluateBenefitFor(Carrot carrot) => -0.2f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => -0.4f;
		public override float EvaluateBenefitFor(Wolf wolf) => 0.1f;
	}
}
