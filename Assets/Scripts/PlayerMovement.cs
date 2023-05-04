using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int gridSize = 1;

    private Vector2Int targetGridPosition;
    private Vector3Int targetPosition;
    private Vector2 movementInput;
    private bool isMoving;

    void Start()
    {
        targetGridPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        targetPosition = (Vector3Int)targetGridPosition;
    }

    void Update()
    {
        if (isMoving) return;

        Vector2Int inputDirection = new Vector2Int(Mathf.RoundToInt(movementInput.x), Mathf.RoundToInt(movementInput.y));

        if (inputDirection != Vector2Int.zero)
        {
            targetGridPosition += inputDirection * gridSize;
            targetPosition = new Vector3Int(targetGridPosition.x, targetGridPosition.y, Mathf.RoundToInt(transform.position.z));
            StartCoroutine(MoveToTargetPosition());
        }
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

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
