using UnityEngine;

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

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			if (castingCreature.stats.currentLevel >= defender.stats.currentLevel)
			{
				defender.stats.currentHealth = 0;
			}
		}
	}
}
