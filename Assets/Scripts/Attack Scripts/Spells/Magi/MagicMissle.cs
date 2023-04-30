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

			public void MagicMissileScript(Creature castingCreature, Creature defender, bool isPlayerAttack)
			{
					if (defender != null)
					{
							castingCreature.currentAbilityPool -= abilityPowerCost;
							isPlayerAttack = castingCreature.CompareTag("Player");

							float damage = castingCreature.GetDamageValue() + castingCreature.GetDamageValue() * magicDamageModifier;
							damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

							if (isPlayerAttack)
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

							currentCooldown = cooldown;
					}
			}
	}
}
