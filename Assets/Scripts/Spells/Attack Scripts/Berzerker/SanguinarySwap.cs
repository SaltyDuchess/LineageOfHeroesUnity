namespace LineageOfHeroes.Spells.Berzerker
{
	public class SanguinarySwap : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Swaps your percentage health and your percentage stamina. Does not end your turn";
		}
		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float hp = castingCreature.stats.percentageHealth;
			float ap = castingCreature.stats.percentageAbilityPool;

			castingCreature.stats.currentHealth = (ap / 100 * castingCreature.stats.healthPool);
			castingCreature.stats.currentAbilityPool = (hp / 100 * castingCreature.stats.abilityPowerPool);

			castingCreature.queuedAbility = null;
		}
	}
}
