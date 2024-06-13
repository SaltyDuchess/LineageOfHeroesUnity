using UnityEngine;

namespace LineageOfHeroes.AttackScripts
{
	public static class MoveTarget
	{
		public static void PushTargetAway(Creature castingCreature, Creature target, int distance)
		{
			Vector2 direction = (target.transform.position - castingCreature.transform.position).normalized;
			Vector3 targetPosition = target.transform.position + (Vector3)(direction * distance);

			// Ensure the target doesn't go out of bounds or into an obstacle
			RaycastHit2D hit = Physics2D.Raycast(target.transform.position, direction, distance, LayerMask.GetMask("Obstacles"));
			if (hit.collider != null)
			{
				targetPosition = hit.point - (Vector2)(direction * 0.5f);
			}

			target.transform.position = targetPosition;
		}

		public static void PullTargetTowards(Creature castingCreature, Creature target)
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