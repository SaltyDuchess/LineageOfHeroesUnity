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

			public void LivelyLightningScript(ICreature castingICreature, ICreature defender, bool isPlayerAttack)
			{
					castingICreature.currentAbilityPool -= abilityPowerCost;

					float damage = castingICreature.GetDamageValue() + castingICreature.GetDamageValue() * magicDamageModifier;
					damage *= calcCritAndDamage.CalculateCritAndDamage(castingICreature);

					damage -= damage * defender.magicDamageResist;

					defender.currentHealth -= damage;

					currentCooldown = cooldown;
			}
	}
}
