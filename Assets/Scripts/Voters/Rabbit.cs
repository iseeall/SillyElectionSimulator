namespace Assets.Scripts.Voters
{
	internal class Rabbit : Voter
	{
		public override string Name => "Rabbits";

		public override string GetOpinion() => "Wolves are evil and should be in jail. And we need more carrots!";

		public Rabbit(int population)
			: base(population)
		{
		}
		public override PolicyReaction GetReactionToPolicy(Policy policy)
		{
			return policy.GetReactionFor(this);
		}
	}
}
