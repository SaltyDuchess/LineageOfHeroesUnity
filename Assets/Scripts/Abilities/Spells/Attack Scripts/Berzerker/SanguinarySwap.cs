using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class SanguinarySwap : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Swaps your percentage health and your percentage stamina. Does not end your turn";
		}
		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			float hp = castingCreature.percentageHealth;
			float ap = castingCreature.percentageAbilityPool;

			castingCreature.currentHealth = ap / 100 * castingCreature.healthPool;
			castingCreature.currentAbilityPool = hp / 100 * castingCreature.abilityPowerPool;
		}
	}
}
