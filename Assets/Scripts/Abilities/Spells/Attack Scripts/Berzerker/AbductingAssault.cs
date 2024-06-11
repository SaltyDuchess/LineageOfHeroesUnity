using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class AbductingAssault : TargetedSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Pulls the targeted enemy next to the player.";
		}

		protected override void ApplySpellEffect(Creature castingCreature, Creature target)
		{
			// Get the player's and target's positions
			Vector2Int playerPosition = new Vector2Int(Mathf.RoundToInt(castingCreature.transform.position.x), Mathf.RoundToInt(castingCreature.transform.position.y));
			Vector2Int targetPosition = new Vector2Int(Mathf.RoundToInt(target.transform.position.x), Mathf.RoundToInt(target.transform.position.y));

			// Calculate the direction from the player to the target
			Vector2Int directionToTarget = targetPosition - playerPosition;

			// Normalize the direction to get a unit vector
			Vector2Int normalizedDirection = new Vector2Int(
				directionToTarget.x != 0 ? directionToTarget.x / Mathf.Abs(directionToTarget.x) : 0,
				directionToTarget.y != 0 ? directionToTarget.y / Mathf.Abs(directionToTarget.y) : 0
			);

			// Calculate the new position for the target, next to the player
			Vector2Int newTargetPosition = playerPosition + normalizedDirection;

			// Set the target's position
			target.transform.position = new Vector3(newTargetPosition.x, newTargetPosition.y, target.transform.position.z);
		}
	}
}
