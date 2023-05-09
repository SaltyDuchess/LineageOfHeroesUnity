using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class MagicMissile : MagiSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 2;
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to the nearest enemy.";
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			if (defender != null)
			{
				float damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * magicDamageModifier;
				damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

				if (castingCreature.IsPlayer)
				{
					// The logic for finding the nearest mob should be handled externally.
				}
				else
				{
					// This assumes the player is tagged "Player" in the game.
					defender = GameObject.FindGameObjectWithTag("Player").GetComponent<Creature>();
				}

				damage -= damage * defender.magicDamageResist;

				defender.currentHealth -= damage;
			}
		}
	}
}
