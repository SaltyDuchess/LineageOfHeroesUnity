using LineageOfHeroes.AttackScripts;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class FatalFinish : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% additional physical damage per 10% missing enemy health. If the enemy is killed, refills entire stamina pool.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, defender, spellData.physDamageModifier * (100 - defender.percentageHealth) / 10);

			if (defender.currentHealth <= 0)
			{
				castingCreature.currentAbilityPool = castingCreature.abilityPowerPool;
			}
		}
	}
}
