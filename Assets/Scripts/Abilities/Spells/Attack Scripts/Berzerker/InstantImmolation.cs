namespace LineageOfHeroes.Spells.Berzerker
{
	public class InstantImmolation : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			physDamageModifier = 0;
			descriptionLong = $"{displayName} --- Cost - 100% of Stamina --- Required Level - {levelRequirement}\nDescription - Instantly kills enemy of equal or lesser level";
		}

		public override bool IsCastable(Creature castingCreature)
		{
			return castingCreature.currentAbilityPool >= castingCreature.abilityPowerPool;
		}

		public override void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			castingCreature.currentAbilityPool -= castingCreature.abilityPowerPool;
			currentCooldown = cooldown;
			castingCreature.queuedAbility = null;

			if (castingCreature.currentLevel >= defender.currentLevel)
			{
				defender.currentHealth = 0;
			}
		}
	}
}
