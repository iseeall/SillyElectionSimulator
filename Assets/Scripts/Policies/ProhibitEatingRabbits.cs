using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ProhibitEatingRabbits : Policy
	{
		public override string Name => "Prohibit eating rabbits";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = -0.5f, Explanation = "You support evil!" };
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = 1f, Explanation = "We love you!" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new() { Reaction = -1f, Explanation = "What are we going to eat now?" };
	}
}
