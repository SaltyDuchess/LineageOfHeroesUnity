using LineageOfHeroes.AttackScripts;

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
			DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, defender, spellData.physDamageModifier);
			StunCreature.StunDefender(defender, stunTurns);
		}
	}
}
