using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class BeastlyBite : SpellBase, ISpell
	{
		float healPercentage = 0.5f;

		new private void Awake()
		{
			base.Awake();
			physDamageModifier = 0.45f;
		}

		// Add Beastly Bite-specific functionality here
		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * physDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.physDamageResist;

			defender.stats.currentHealth -= damage;

			castingCreature.stats.currentHealth += damage * healPercentage;

			if (castingCreature.stats.currentHealth > castingCreature.stats.healthPool)
			{
				castingCreature.stats.currentHealth = castingCreature.stats.healthPool;
			}
		}
	}
}
