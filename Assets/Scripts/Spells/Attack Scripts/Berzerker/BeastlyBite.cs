namespace LineageOfHeroes.Spells.Berzerker
{
	public class BeastlyBite : BerzerkerSpellBase
	{
		float healPercentage = 0.5f;

		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% additional physical damage and heals for {healPercentage * 100}% of damage dealt after enemy damage reduction.";
		}

		// Add Beastly Bite-specific functionality here
		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * physDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.physDamageResist;

			defender.currentHealth -= damage;

			castingCreature.currentHealth += damage * healPercentage;

			if (castingCreature.currentHealth > castingCreature.healthPool)
			{
				castingCreature.currentHealth = castingCreature.healthPool;
			}
		}
	}
}
