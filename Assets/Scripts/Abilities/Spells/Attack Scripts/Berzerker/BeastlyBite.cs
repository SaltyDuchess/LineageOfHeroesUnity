using LineageOfHeroes.AttackScripts;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class BeastlyBite : BerzerkerSpellBase
	{
		[SerializeField] protected float healPercentage = 0.5f;

		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% additional physical damage and heals for {healPercentage * 100}% of damage dealt after enemy damage reduction.";
		}

		// Add Beastly Bite-specific functionality here
		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			float damage = DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, defender, spellData.physDamageModifier);

			castingCreature.currentHealth += damage * healPercentage;

			if (castingCreature.currentHealth > castingCreature.healthPool)
			{
				castingCreature.currentHealth = castingCreature.healthPool;
			}
		}
	}
}
