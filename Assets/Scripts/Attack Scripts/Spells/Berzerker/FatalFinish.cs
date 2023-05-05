namespace LineageOfHeroes.Spells.Berzerker
{
	public class FatalFinish : SpellBase, ISpell
	{
		new private void Awake()
		{
			base.Awake();
			physDamageModifier = 0.2f;
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
