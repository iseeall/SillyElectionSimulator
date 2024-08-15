using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ProhibitEatingCarrots : Policy
	{
		public override string Name => "Prohibit eating carrots";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = 1f, Explanation = "We love you!" };
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = -1f, Explanation = "What are we going to eat now?" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new(){ Reaction = -0.1f, Explanation = "You sure? Will there be enough rabbits after this?" };
	}
}
