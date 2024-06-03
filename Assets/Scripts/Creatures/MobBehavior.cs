using System.Collections;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
	public GameObject player;
	public int gridSize = 1;
	public float moveSpeed = 5.0f;
	private bool isMoving;
	private Creature creature;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		creature = GetComponent<Creature>();
	}

	public bool IsPlayerInRange(float range)
	{
		if (player == null) return false;
		float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
		return distanceToPlayer <= range;
	}

	public void PerformAttack()
	{
		Creature playerCreature = player.GetComponent<Creature>();
		if (playerCreature != null)
		{
			creature.TryAttack(playerCreature);
		}
	}

	public void MoveTowardsPlayer(System.Action onMoveComplete)
	{
		if (player == null) return;

		Vector2Int currentPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		Vector2Int playerPosition = new Vector2Int(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y));

		Vector2Int direction = playerPosition - currentPosition;
		Vector2Int gridDirection = new Vector2Int(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));

		Vector2Int targetGridPosition = currentPosition + gridDirection;
		Creature targetCreature = Creature.GetCreatureAtGridPosition(targetGridPosition);

		bool attacked = false;

		if (targetCreature != null && targetCreature.IsPlayer)
		{
			attacked = creature.TryAttack(targetCreature);
		}

		if (targetCreature != null && !targetCreature.IsPlayer)
		{
			Vector2Int[] directions = GetDirectionOrder(gridDirection);
			foreach (Vector2Int dir in directions)
			{
				Vector2Int potentialTargetPosition = currentPosition + dir;
				Creature potentialTargetCreature = Creature.GetCreatureAtGridPosition(potentialTargetPosition);

				if (potentialTargetCreature == null || potentialTargetCreature.IsPlayer)
				{
					targetGridPosition = potentialTargetPosition;
					break;
				}
			}
		}

		if (!attacked)
		{
			StartCoroutine(MoveToTargetPosition(targetGridPosition, onMoveComplete));
		}
		else
		{
			onMoveComplete?.Invoke();
		}
	}

	private Vector2Int[] GetDirectionOrder(Vector2Int gridDirection)
	{
		if (gridDirection == Vector2Int.up)
		{
			return new Vector2Int[]
			{
								new Vector2Int(-1, 1), new Vector2Int(1, 1), new Vector2Int(0, 1),
								new Vector2Int(-1, 0), new Vector2Int(1, 0), new Vector2Int(-1, -1),
								new Vector2Int(1, -1), new Vector2Int(0, -1)
			};
		}
		else if (gridDirection == Vector2Int.right)
		{
			return new Vector2Int[]
			{
								new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(1, 0),
								new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(-1, 1),
								new Vector2Int(-1, -1), new Vector2Int(-1, 0)
			};
		}
		else if (gridDirection == Vector2Int.down)
		{
			return new Vector2Int[]
			{
								new Vector2Int(-1, -1), new Vector2Int(1, -1), new Vector2Int(0, -1),
								new Vector2Int(-1, 0), new Vector2Int(1, 0), new Vector2Int(-1, 1),
								new Vector2Int(1, 1), new Vector2Int(0, 1)
			};
		}
		else
		{
			return new Vector2Int[]
			{
								new Vector2Int(-1, 1), new Vector2Int(-1, -1), new Vector2Int(-1, 0),
								new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 1),
								new Vector2Int(1, -1), new Vector2Int(1, 0)
			};
		}
	}

	IEnumerator MoveToTargetPosition(Vector2Int targetGridPosition, System.Action onMoveComplete)
	{
		isMoving = true;
		Vector3 targetPosition = new Vector3(targetGridPosition.x, targetGridPosition.y, transform.position.z);

		while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
			yield return null;
		}

		transform.position = targetPosition;
		isMoving = false;
		onMoveComplete?.Invoke();
	}
}
