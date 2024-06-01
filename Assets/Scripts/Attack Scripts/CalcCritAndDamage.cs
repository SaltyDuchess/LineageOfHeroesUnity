using LineageOfHeroes.Randomization;

namespace LineageOfHeroes.AttackScripts
{
	public static class CalcCritAndDamage
	{
		public static float CalculateCritAndDamage<T>(T attacker) where T : Creature
		{
				float universalCritChance = StaticCombatModifiers.universalCritChance;
				float universalCritMultiplier = StaticCombatModifiers.universalCritMultiplier;
				float finalCritChance = universalCritChance + attacker.critChanceModifier;

				if (RandomGenerator.Range(1, 101) <= finalCritChance)
				{
						return universalCritMultiplier + attacker.critDamageMultiplier;
				}
				else
				{
						return 1;
				}
		}
	}
}