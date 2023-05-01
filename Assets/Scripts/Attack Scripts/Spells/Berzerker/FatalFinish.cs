namespace LineageOfHeroes.Spells.Berzerker
{
	public class FatalFinish : SpellBase, ISpell
	{
			new private void Awake()
			{
				base.Awake();
				physDamageModifier = 0.2f;
			}

		public void ExecuteFatalFinish(ICreature attacker, ICreature defender)
			{
					float damage;

					attacker.currentAbilityPool -= abilityPowerCost;

					damage = attacker.GetDamageValue() + attacker.GetDamageValue() * (physDamageModifier * ((100 - defender.percentageHealth) / 10));
					damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

					damage -= damage * defender.physDamageResist;

					defender.currentHealth -= damage;

					if (defender.currentHealth <= 0)
					{
							attacker.currentAbilityPool = attacker.abilityPowerPool;
					}

					currentCooldown = cooldown;
			}
	}
}
