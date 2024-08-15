using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class DestroyAllCarrots : Policy
	{
		public override string Name => "Destroy all carrots";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = -2f, Explanation = "[attempting to assassinate you]" };
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = -1f, Explanation = "Whaaa? We need the carrots!" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new() { Reaction = -0.1f, Explanation = "Eh? Don't rabbits eat them? And we need the rabbits" };
	}
}
