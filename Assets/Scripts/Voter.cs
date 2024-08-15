namespace Assets.Scripts
{
	internal abstract class Voter
	{
		public abstract string Name { get; }
		public abstract string GetOpinion();

		public abstract bool WouldSupportPolicy(Policy policy);
	}
}
