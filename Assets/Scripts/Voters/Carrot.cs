namespace Assets.Scripts.Voters
{
	internal class Carrot : Voter
	{
		public override string Name => "Carrots";

		public override string GetOpinion() => "Rabbits are evil! Wolves will free us from the rabbits, so we need more wolves.";

		public Carrot(int population)
			: base(population)
		{
		}
		public override PolicyReaction GetReactionToPolicy(Policy policy)
		{
			return policy.GetReactionFor(this);
		}
	}
}
