namespace Assets.Scripts.Respondents
{
	internal class Rabbit : Respondent
	{
		public override string Name => "Rabbit";

		public override string GetOpinion() => "Wolves are evil and should be in jail. And we need more carrots!";

		public override bool WouldSupportPolicy(Policy policy)
		{
			return policy.EvaluateBenefitFor(this) > 0;
		}
	}
}
