using System.Diagnostics;
using LineageOfHeroes.Randomization;

namespace LineageOfHeroes.AttackScripts
{
	public static class DealDOTDamageToCreature
	{
		public static void DealDOTDamage(Creature defender)
		{
			foreach (DOTData dot in defender.damageOverTimeEffects)
			{
				switch (dot.dotType)
				{
					case DOTType.Bleed:
						bool isCrit = false;
						if (GlobalEffectsManager.Instance.bleedsCanCrit)
						{
							isCrit = RandomGenerator.Range(1, 101) <= GlobalEffectsManager.Instance.bleedCritChance;
						}
						defender.currentHealth -= isCrit ? dot.dotAmount * GlobalEffectsManager.Instance.bleedCritModifier : dot.dotAmount;
						dot.dotTurns--;
						if (dot.dotTurns <= 0)
						{
							defender.damageOverTimeEffects.Remove(dot);
						}
						break;
				}
			}
		}
	}
}