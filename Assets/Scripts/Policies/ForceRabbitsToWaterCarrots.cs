using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class ForceRabbitsToWaterCarrots : Policy
	{
		public override string Name => "Force rabbits to water carrots";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = -0.2f , Explanation = "You can't fool us! Rabbits still need us just for food."};
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = -0.4f, Explanation = "Eh? Why do we have to do everything ourselves?" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new() { Reaction = 0.1f, Explanation = "Well, it's between rabbits and carrots. Still, more carrots = more rabbits = good" };
	}
}
