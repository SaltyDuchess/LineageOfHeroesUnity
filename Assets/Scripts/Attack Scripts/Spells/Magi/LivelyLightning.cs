using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class LivelyLightning : SpellBase, ISpell
	{
			new private void Awake()
			{
				base.Awake();
				magicDamageModifier = 4;
			}

			public void LivelyLightningScript(Creature castingCreature, Creature defender, bool isPlayerAttack)
			{
					castingCreature.currentAbilityPool -= abilityPowerCost;

					float damage = castingCreature.GetDamageValue() + castingCreature.GetDamageValue() * magicDamageModifier;
					damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

					damage -= damage * defender.magicDamageResist;

					defender.currentHealth -= damage;

					currentCooldown = cooldown;
			}
	}
}
