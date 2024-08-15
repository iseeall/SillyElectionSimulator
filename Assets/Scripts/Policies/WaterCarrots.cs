using Assets.Scripts.Respondents;

namespace Assets.Scripts.Policies
{
	internal class WaterCarrots : Policy
	{
		public override string Name => "Water carrots!";
		public override float EvaluateBenefitFor(Carrot carrot) => 1f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => 0.2f;
		public override float EvaluateBenefitFor(Wolf wolf) => 0.1f;
	}
}
