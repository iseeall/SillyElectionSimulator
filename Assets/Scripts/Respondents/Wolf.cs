namespace Assets.Scripts.Respondents
{
	internal class Wolf : Respondent
	{
		public override string Name => "Wolf";

		public override string GetOpinion() => "We need more rabbits! And since carrots are needed for rabbits to grow, we need more carrots as well.";

		public override bool WouldSupportPolicy(Policy policy)
		{
			return policy.EvaluateBenefitFor(this) > 0;
		}
	}
}
