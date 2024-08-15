namespace Assets.Scripts.Voters
{
	internal class Wolf : Voter
	{
		public override string Name => "Wolves";

		public override string GetOpinion() => "We need more rabbits! And since carrots are needed for rabbits to grow, we need more carrots as well.";

		public Wolf(int population)
			: base(population)
		{
		}
		public override PolicyReaction GetReactionToPolicy(Policy policy)
		{
			return policy.GetReactionFor(this);
		}
	}
}
