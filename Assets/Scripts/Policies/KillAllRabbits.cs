using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class KillAllRabbits : Policy
	{
		public override string Name => "Kill all rabbits!";
		public override float EvaluateBenefitFor(Carrot carrot) => 1f;
		public override float EvaluateBenefitFor(Rabbit rabbit) => -2f;
		public override float EvaluateBenefitFor(Wolf wolf) => -1f;
	}
}
