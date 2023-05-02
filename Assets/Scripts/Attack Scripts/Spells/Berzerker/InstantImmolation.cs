using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class InstantImmolation : SpellBase, ISpell
	{
		new private void Awake()
		{
			base.Awake();
			physDamageModifier = 0;
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
