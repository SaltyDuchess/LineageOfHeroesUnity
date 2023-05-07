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

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			castingCreature.stats.currentAbilityPool -= abilityPowerCost;

			float damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * magicDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.magicDamageResist;

			defender.stats.currentHealth -= damage;
		}
	}
}
