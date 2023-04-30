using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class StunningStrike : SpellBase, ISpell
	{
			new private void Awake()
			{
				base.Awake();
				physDamageModifier = 0;
				stunTurns = 2;
			}

			public void ExecuteStunningStrike(Creature attacker, Creature defender)
			{
					float damage;

					attacker.currentAbilityPool -= abilityPowerCost;

					damage = attacker.GetDamageValue() + attacker.GetDamageValue() * physDamageModifier;
					damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

					damage -= damage * defender.physDamageResist;

					defender.currentHealth -= damage;

					defender.speedPool -= stunTurns * 100;

					currentCooldown = cooldown;
			}
	}
}
