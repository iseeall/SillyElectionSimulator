namespace Assets.Scripts
{
	internal abstract class Voter
	{
		public abstract string Name { get; }
		public int Population { get; private set; }
		public abstract string GetOpinion();

		public Voter(int population)
		{
			this.Population = population;
		}

		public abstract PolicyReaction GetReactionToPolicy(Policy policy);
	}
}
