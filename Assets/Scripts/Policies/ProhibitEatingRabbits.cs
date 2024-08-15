using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ProhibitEatingRabbits : Policy
	{
		public override string Name => "Prohibit eating rabbits!";
		public override float EvaluateBenefitFor(Carrot carrot) => -0.2f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => 1f;
		public override float EvaluateBenefitFor(Wolf wolf) => -1f;
	}
}
