using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class BeastlyBite : SpellBase, ISpell
	{
			float healPercentage = 0.5f;

			new private void Awake()
			{
				base.Awake();
				physDamageModifier = 0.45f;
			}

			// Add Beastly Bite-specific functionality here
			public void ExecuteBeastlyBite(ICreature attacker, ICreature defender)
			{
					float damage;

					attacker.currentAbilityPool -= abilityPowerCost;

					damage = attacker.GetDamageValue() + attacker.GetDamageValue() * physDamageModifier;
					damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

					damage -= damage * defender.physDamageResist;

					defender.currentHealth -= damage;

					attacker.currentHealth += damage * healPercentage;

					if (attacker.currentHealth > attacker.healthPool)
					{
							attacker.currentHealth = attacker.healthPool;
					}

					currentCooldown = cooldown;
			}
	}
}
