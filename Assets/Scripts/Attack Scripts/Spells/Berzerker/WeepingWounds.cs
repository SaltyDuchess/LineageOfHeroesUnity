using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class WeepingWound : SpellBase, ISpell
	{
			[SerializeField] private Creature player;

			new private void Awake()
			{
				base.Awake();
				DOT = (float)(player.GetDamageValue() * .5);
				physDamageModifier = -0.1f;
			}

			public void ExecuteWeepingWound(Creature attacker, Creature defender)
			{
					float damage;

					attacker.currentAbilityPool -= abilityPowerCost;

					damage = attacker.GetDamageValue()  + attacker.GetDamageValue() * physDamageModifier;
					damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

					damage -= damage * defender.physDamageResist;

					defender.currentHealth -= damage;

					defender.damageOverTime = DOT;
					defender.damageOverTimeTurns = DOTTurns;

					currentCooldown = cooldown;
			}
	}
}
