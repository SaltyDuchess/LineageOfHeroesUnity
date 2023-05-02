using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class MagicMissile : SpellBase, ISpell
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 2;
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			if (defender != null)
			{
				float damage = castingCreature.stats.GetDamageValue() + castingCreature.stats.GetDamageValue() * magicDamageModifier;
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

				damage -= damage * defender.stats.magicDamageResist;

				defender.stats.currentHealth -= damage;
			}
		}
	}
}
