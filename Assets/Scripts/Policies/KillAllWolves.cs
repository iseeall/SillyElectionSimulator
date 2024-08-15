using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class KillAllWolves : Policy
	{
		public override string Name => "Kill all wolves!";
		public override float EvaluateBenefitFor(Carrot carrot) => -0.2f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => 1f;
		public override float EvaluateBenefitFor(Wolf wolf) => -2f;
	}
}
