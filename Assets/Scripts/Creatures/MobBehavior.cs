using System.Collections;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
	public GameObject player;
	public int gridSize = 1;
	public float moveSpeed = 5.0f;
	private bool isMoving;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void MoveTowardsPlayer(System.Action onMoveComplete)
	{
		if (player == null) return;

		Vector2Int currentPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		Vector2Int playerPosition = new Vector2Int(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y));

		Vector2Int direction = playerPosition - currentPosition;
		Vector2Int gridDirection = new Vector2Int(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));

		Vector2Int targetGridPosition = currentPosition + gridDirection;
		ICreature targetCreature = Creature.GetCreatureAtGridPosition(targetGridPosition);

		// Check if there is a creature at the target position
		if (targetCreature != null)
		{
			// If an attack is performed, skip the movement step
			if (GetComponent<ICreature>().TryAttack(targetCreature))
			{
				onMoveComplete?.Invoke();
				return;
			}
		}

		StartCoroutine(MoveToTargetPosition(targetGridPosition, onMoveComplete));
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
