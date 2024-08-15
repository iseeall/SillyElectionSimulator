using Assets.Scripts.Voters;

namespace Assets.Scripts
{
	internal abstract class Policy
	{
		public abstract string Name { get; }
		public abstract PolicyReaction GetReactionFor(Carrot carrot);
		public abstract PolicyReaction GetReactionFor(Rabbit rabbit);
		public abstract PolicyReaction GetReactionFor(Wolf wolf);
	}
}
