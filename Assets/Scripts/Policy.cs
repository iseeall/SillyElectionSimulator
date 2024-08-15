using Assets.Scripts.Voters;

namespace Assets.Scripts
{
	internal abstract class Policy
	{
		public abstract string Name { get; }
		public abstract float EvaluateBenefitFor(Carrot carrot);
		public abstract float EvaluateBenefitFor(Rabbit rabbit);
		public abstract float EvaluateBenefitFor(Wolf wolf);
	}
}
