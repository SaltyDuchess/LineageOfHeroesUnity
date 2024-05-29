namespace LineageOfHeroes.Spells.Berzerker
{
	public class StunningStrike : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Stuns target for {stunTurns} turns";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			float damage;

			damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * physDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.physDamageResist;

			defender.currentHealth -= damage;

			defender.speedPool -= stunTurns * 100;
		}
	}
}
