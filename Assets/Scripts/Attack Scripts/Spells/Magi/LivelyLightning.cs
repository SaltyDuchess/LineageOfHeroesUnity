using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class LivelyLightning : SpellBase, ISpell
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 4;
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			castingCreature.stats.currentAbilityPool -= abilityPowerCost;

			float damage = castingCreature.stats.GetDamageValue() + castingCreature.stats.GetDamageValue() * magicDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.magicDamageResist;

			defender.stats.currentHealth -= damage;
		}
	}
}
