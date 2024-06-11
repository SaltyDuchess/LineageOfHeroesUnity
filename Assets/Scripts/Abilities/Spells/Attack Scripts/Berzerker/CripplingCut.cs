using LineageOfHeroes.AttackScripts;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class CripplingCut : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Inflicts {physDamageModifier * 100}% physical damage and disables movement for {spellData.movementDisabledTurns} turns.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);

			// Inflict damage
			DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, defender, spellData.physDamageModifier);

			// Apply movement disable effect
			defender.movementDisabledTurns = spellData.movementDisabledTurns;
			StunCreature.StunDefender(defender, stunTurns);
		}
	}
}
