namespace LineageOfHeroes.Spells.Berzerker
{
	public class SanguinarySwap : SpellBase, ISpell
	{
			public void ExecuteSanguinarySwap(Creature castingCreature)
			{
					float hp = castingCreature.percentageHealth;
					float ap = castingCreature.percentageAbilityPool;

					castingCreature.currentHealth = (ap / 100 * castingCreature.healthPool);
					castingCreature.currentAbilityPool = (hp / 100 * castingCreature.abilityPowerPool);

					currentCooldown = cooldown;

					castingCreature.queuedAbility = null;
			}
}
}
