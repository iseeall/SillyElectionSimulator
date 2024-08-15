using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ProhibitEatingCarrots : Policy
	{
		public override string Name => "Prohibit eating carrots!";
		public override float EvaluateBenefitFor(Carrot carrot) => 1f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => -1f;
		public override float EvaluateBenefitFor(Wolf wolf) => -0.1f;
	}
}
