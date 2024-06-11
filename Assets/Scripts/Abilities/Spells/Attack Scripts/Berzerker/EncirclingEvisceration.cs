using LineageOfHeroes.AttackScripts;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class EncirclingEvisceration : BerzerkerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals damage to all enemies adjacent to the player.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);

			// Get the player's position
			Vector2Int playerPosition = new Vector2Int(Mathf.RoundToInt(castingCreature.transform.position.x), Mathf.RoundToInt(castingCreature.transform.position.y));

			// Define the positions around the player (including diagonals)
			Vector2Int[] adjacentPositions = new Vector2Int[]
			{
								playerPosition + Vector2Int.up,
								playerPosition + Vector2Int.down,
								playerPosition + Vector2Int.left,
								playerPosition + Vector2Int.right,
								playerPosition + new Vector2Int(1, 1),
								playerPosition + new Vector2Int(1, -1),
								playerPosition + new Vector2Int(-1, 1),
								playerPosition + new Vector2Int(-1, -1)
			};

			// Loop through the adjacent positions
			foreach (var position in adjacentPositions)
			{
				// Check if there is a creature at this position
				Creature target = Creature.GetCreatureAtGridPosition(position);

				// If there is an enemy creature, apply damage
				if (target != null && !target.IsPlayer)
				{
					DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, target, spellData.physDamageModifier);
				}
			}
		}
	}
}
