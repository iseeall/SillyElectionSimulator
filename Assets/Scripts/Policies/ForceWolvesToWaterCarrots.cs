using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ForceWolvesToWaterCarrots : Policy
	{
		public override string Name => "Force wolves to water carrots";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = 1f, Explanation = "Great! Finally someone is taking care of us"};
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = 0.2f, Explanation = "Half-measures won't solve this. Helping with carrots doesn't excuse their crime of eating us" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new() { Reaction = -0.8f, Explanation = "Why us? It's rabbits who need carrots" };
	}
}
