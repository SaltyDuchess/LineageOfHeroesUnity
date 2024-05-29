using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class LivelyLightning : MagiSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 4;
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to the targeted enemy.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			castingCreature.currentAbilityPool -= abilityPowerCost;

			float damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * magicDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.magicDamageResist;

			defender.currentHealth -= damage;
		}
	}
}
