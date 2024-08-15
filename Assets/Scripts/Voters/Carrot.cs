namespace Assets.Scripts.Voters
{
	internal class Carrot : Voter
	{
		public override string Name => "Carrot";

		public override string GetOpinion() => "Rabbits are evil! And since wolves will free us from the rabbits, we need more wolves.";

		public override bool WouldSupportPolicy(Policy policy)
		{
			return policy.EvaluateBenefitFor(this) > 0;
		}
	}
}
