using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5.0f;
	public int gridSize = 1;
	public Vector2Int lastMoveDirection;

	private Vector2Int targetGridPosition;
	private Vector3Int targetPosition;
	private bool isMoving;
	private AbilityManager abilityManager;
	private Player player;

	void Start()
	{
		targetGridPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		targetPosition = (Vector3Int)targetGridPosition;
		abilityManager = FindObjectOfType<AbilityManager>();
		player = GetComponent<Player>();
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
			player.TakeAction();
			return;
		}
		else lastMoveDirection = moveDirection;

		Vector2Int currentGridPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
		Vector2Int newGridPosition = currentGridPosition + moveDirection * gridSize;
		Creature targetCreature = Creature.GetCreatureAtGridPosition(newGridPosition);

		// Check if there is a creature at the target position
		if (targetCreature != null)
		{
			// If an attack is performed, skip the movement step
			if (GetComponent<ICreature>().TryAttack(targetCreature))
			{
				player.TakeAction();
				return;
			}
		}

		// Check for any colliders at the target position
		Collider2D hitCollider = Physics2D.OverlapBox(new Vector2(newGridPosition.x, newGridPosition.y), Vector2.one * 0.5f, 0f);
		if (hitCollider != null && !hitCollider.isTrigger)
		{
			// The target position is blocked, so the player cannot move there
			GetComponent<Player>().TakeAction();
			return;
		}

		targetGridPosition = newGridPosition;
		targetPosition = new Vector3Int(targetGridPosition.x, targetGridPosition.y, Mathf.RoundToInt(transform.position.z));
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
		GetComponent<Player>().TakeAction();
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
