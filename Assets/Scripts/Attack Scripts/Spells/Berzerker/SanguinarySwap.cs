namespace LineageOfHeroes.Spells.Berzerker
{
	public class SanguinarySwap : SpellBase, ISpell
	{
			public void ExecuteSanguinarySwap(ICreature castingICreature)
			{
					float hp = castingICreature.percentageHealth;
					float ap = castingICreature.percentageAbilityPool;

					castingICreature.currentHealth = (ap / 100 * castingICreature.healthPool);
					castingICreature.currentAbilityPool = (hp / 100 * castingICreature.abilityPowerPool);

					currentCooldown = cooldown;

					castingICreature.queuedAbility = null;
			}
}
}
