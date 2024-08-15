using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class KillAllRabbits : Policy
	{
		public override string Name => "Kill all rabbits";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = 1f, Explanation = "Freedom at last!" };
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = -2f, Explanation = "[attempting to assassinate you]" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new() { Reaction = -1f, Explanation = "But we need rabbits for food!" };
	}
}
