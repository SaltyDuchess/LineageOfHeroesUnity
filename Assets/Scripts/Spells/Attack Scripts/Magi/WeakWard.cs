namespace LineageOfHeroes.Spells.Magi
{
	public class WeakWard : MagiSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Makes you invulnerable to the next attack. Does not end your turn";
		}
		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);

			if (castingCreature.invulnerabilityCharges == 0)
			{
				castingCreature.invulnerabilityCharges += 1;
			}
		}
	}
}
