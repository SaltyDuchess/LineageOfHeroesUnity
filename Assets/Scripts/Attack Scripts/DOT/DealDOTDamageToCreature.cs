using LineageOfHeroes.Randomization;
using UnityEngine;
using System.Collections.Generic;

namespace LineageOfHeroes.AttackScripts
{
	public static class DealDOTDamageToCreature
	{
		public static void DealDOTDamage(Creature defender)
		{
			// Iterate over the list in reverse order to avoid issues when removing items
			for (int i = defender.damageOverTimeEffects.Count - 1; i >= 0; i--)
			{
				DOTData dot = defender.damageOverTimeEffects[i];

				switch (dot.dotType)
				{
					case DOTType.Bleed:
						bool isCrit = false;
						if (GlobalEffectsManager.Instance.bleedsCanCrit)
						{
							isCrit = RandomGenerator.Range(1, 101) <= GlobalEffectsManager.Instance.bleedCritChance;
						}
						var bleedDamage = isCrit ? dot.dotAmount * GlobalEffectsManager.Instance.bleedCritModifier : dot.dotAmount;
						defender.currentHealth -= bleedDamage;
						if (GlobalEffectsManager.Instance.bleedsHealPlayer && defender is Mob)
						{
							Player player = Object.FindObjectOfType<Player>();
							if (player != null)
							{
								Debug.Log(player.currentHealth);
								player.currentHealth += bleedDamage;
								Debug.Log(player.currentHealth);
							}
						}
						break;
				}

				dot.dotTurns--;
				if (dot.dotTurns <= 0)
				{
					defender.damageOverTimeEffects.RemoveAt(i);
				}
			}
		}
	}
}
