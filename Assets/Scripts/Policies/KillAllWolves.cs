using Assets.Scripts.Voters;

namespace Assets.Scripts.Policies
{
	internal class KillAllWolves : Policy
	{
		public override string Name => "Kill all wolves";
		public override PolicyReaction GetReactionFor(Carrot carrot) => new() { Reaction = -0.2f, Explanation = "Who will save us from the evil rabbits?" };
		public override PolicyReaction GetReactionFor(Rabbit rabbit) => new() { Reaction = 1f, Explanation = "Freedom, finally!" };
		public override PolicyReaction GetReactionFor(Wolf wolf) => new() { Reaction = -2f, Explanation = "[attempting to assassinate you]" };
	}
}
