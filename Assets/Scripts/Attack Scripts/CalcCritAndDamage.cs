using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.AttackScripts
{
	public static class CalcCritAndDamage
	{
		public static float CalculateCritAndDamage<T>(T attacker) where T : Creature
		{
			float universalCritChance = StaticCombatModifiers.universalCritChance;
			float universalCritMultiplier = StaticCombatModifiers.universalCritMultiplier;
			float finalCritChance = universalCritChance + attacker.critChanceModifier;

			bool isCrit = RandomGenerator.Range(1, 101) <= finalCritChance;

			if (GlobalCombatFlags.Instance.playerCritQueued)
			{
				isCrit = true;
				GlobalCombatFlags.Instance.playerCritQueued = false;
				Debug.Log("playerCritQueued consumed. Automatic crit applied.");
			}

			if (isCrit)
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
