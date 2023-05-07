namespace LineageOfHeroes.Spells.Berzerker
{
	public class FatalFinish : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% additional physical damage per 10% missing enemy health. If the enemy is killed, refills entire stamina pool.";
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * (physDamageModifier * ((100 - defender.stats.percentageHealth) / 10));
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.physDamageResist;

			defender.stats.currentHealth -= damage;

			if (defender.stats.currentHealth <= 0)
			{
				castingCreature.stats.currentAbilityPool = castingCreature.stats.abilityPowerPool;
			}
		}
	}
}
