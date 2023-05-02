namespace LineageOfHeroes.Spells.Berzerker
{
	public class SanguinarySwap : SpellBase, ISpell
	{
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
