using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class InstantImmolation : SpellBase, ISpell
	{
			new private void Awake()
			{
				base.Awake();
				physDamageModifier = 0;
			}

			public void ExecuteInstantImmolation(Creature attacker, Creature defender)
			{
					if (attacker.currentLevel >= defender.currentLevel)
					{
							attacker.currentAbilityPool -= attacker.abilityPowerPool;
							defender.currentHealth = 0;
							currentCooldown = cooldown;
					}
			}
	}
}
