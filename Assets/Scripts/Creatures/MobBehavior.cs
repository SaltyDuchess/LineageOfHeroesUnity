using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
	public GameObject player;
	public int gridSize = 1;
	public float moveSpeed = 5.0f;
	private bool isMoving;
	private Creature creature;
	public LayerMask obstacleLayer; // Add a public LayerMask for obstacles

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

		Vector2Int startGridPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		Vector2Int targetGridPosition = new Vector2Int(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y));

		List<Vector2Int> path = FindPath(startGridPosition, targetGridPosition);

		if (path.Count > 1)
		{
			Vector2Int nextGridPosition = path[1]; // The first position is the mob's current position
			Creature targetCreature = Creature.GetCreatureAtGridPosition(nextGridPosition);

			if (targetCreature != null && targetCreature.IsPlayer)
			{
				PerformAttack();
				onMoveComplete?.Invoke();
			}
			else
			{
				StartCoroutine(MoveToTargetPosition(nextGridPosition, onMoveComplete));
			}
		}
		else
		{
			onMoveComplete?.Invoke();
		}
	}

	private List<Vector2Int> FindPath(Vector2Int start, Vector2Int goal)
	{
		Queue<Vector2Int> frontier = new Queue<Vector2Int>();
		frontier.Enqueue(start);

		Dictionary<Vector2Int, Vector2Int?> cameFrom = new Dictionary<Vector2Int, Vector2Int?>
				{
						{ start, null }
				};

		while (frontier.Count > 0)
		{
			Vector2Int current = frontier.Dequeue();

			if (current == goal)
			{
				break;
			}

			foreach (Vector2Int next in GetNeighbors(current))
			{
				if (!cameFrom.ContainsKey(next) && CanMoveToPosition(next))
				{
					frontier.Enqueue(next);
					cameFrom[next] = current;
				}
			}
		}

		List<Vector2Int> path = new List<Vector2Int>();
		Vector2Int? currentPathNode = goal;

		while (currentPathNode != null)
		{
			path.Add(currentPathNode.Value);
			currentPathNode = cameFrom[currentPathNode.Value];
		}

		path.Reverse();
		return path;
	}

	private IEnumerable<Vector2Int> GetNeighbors(Vector2Int gridPosition)
	{
		Vector2Int[] directions = new Vector2Int[]
		{
						Vector2Int.up,
						Vector2Int.down,
						Vector2Int.left,
						Vector2Int.right,
						new Vector2Int(1, 1), // Diagonal up-right
            new Vector2Int(-1, 1), // Diagonal up-left
            new Vector2Int(1, -1), // Diagonal down-right
            new Vector2Int(-1, -1) // Diagonal down-left
		};

		foreach (Vector2Int direction in directions)
		{
			yield return gridPosition + direction;
		}
	}

	private bool CanMoveToPosition(Vector2Int gridPosition)
	{
		// Check if there is an obstacle at the target position using the obstacleLayer
		Collider2D collider = Physics2D.OverlapCircle(new Vector2(gridPosition.x, gridPosition.y), 0.1f, obstacleLayer);
		return collider == null;
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
