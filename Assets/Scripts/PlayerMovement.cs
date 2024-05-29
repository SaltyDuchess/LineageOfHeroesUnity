using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5.0f;
	public int gridSize = 1;

	private Vector2Int targetGridPosition;
	private Vector3Int targetPosition;
	private bool isMoving;
	private AbilityManager abilityManager;

	void Start()
	{
		targetGridPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		targetPosition = (Vector3Int)targetGridPosition;
		abilityManager = FindObjectOfType<AbilityManager>();
	}
	void Update()
	{
		if (isMoving) return;
	}

	void Move(Vector2Int moveDirection)
	{
		abilityManager.AdvanceCooldownsOnActiveAbilities();
		if (moveDirection == Vector2Int.zero)
		{
			GetComponent<Player>().EndTurn();
			return;
		}

		Vector2Int currentGridPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		Vector2Int targetGridPosition = currentGridPosition + moveDirection * gridSize;
		Creature targetCreature = Creature.GetCreatureAtGridPosition(targetGridPosition);

		// Check if there is a creature at the target position
		if (targetCreature != null)
		{
			// If an attack is performed, skip the movement step
			if (GetComponent<ICreature>().TryAttack(targetCreature))
			{
				GetComponent<Player>().EndTurn();

				return;
			}
		}

		this.targetGridPosition = targetGridPosition;
		targetPosition = new Vector3Int(this.targetGridPosition.x, this.targetGridPosition.y, Mathf.RoundToInt(transform.position.z));
		StartCoroutine(MoveToTargetPosition());
	}


	IEnumerator MoveToTargetPosition()
	{
		isMoving = true;

		while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
			yield return null;
		}

		transform.position = targetPosition;
		isMoving = false;

		// End the player's turn after moving
		GetComponent<Player>().EndTurn();
	}

	// Input action methods
	public void OnMoveUpLeft() { Move(new Vector2Int(-1, 1)); }
	public void OnMoveUp() { Move(new Vector2Int(0, 1)); }
	public void OnMoveUpRight() { Move(new Vector2Int(1, 1)); }
	public void OnMoveLeft() { Move(new Vector2Int(-1, 0)); }
	public void OnSkipTurn() { Move(new Vector2Int(0, 0)); }
	public void OnMoveRight() { Move(new Vector2Int(1, 0)); }
	public void OnMoveDownLeft() { Move(new Vector2Int(-1, -1)); }
	public void OnMoveDown() { Move(new Vector2Int(0, -1)); }
	public void OnMoveDownRight() { Move(new Vector2Int(1, -1)); }
}
