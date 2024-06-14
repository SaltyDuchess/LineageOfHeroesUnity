namespace LineageOfHeroes.Spells.Berzerker
{
	public class RevitalizingRespite : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Fully restores casting creature's ability power.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);

			if (castingCreature != null)
			{
				// Set the casting creature's current speed pool to the maximum speed pool
				castingCreature.currentAbilityPool = castingCreature.abilityPowerPool;
			}
		}
	}
}
