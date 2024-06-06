using System.Linq;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public enum DoorOrientation { North, South, East, West }
	public DoorOrientation orientation;
	private TurnManager turnManager;
	private Collider2D doorCollider;

	private void Awake()
	{
		turnManager = FindObjectOfType<TurnManager>();
		doorCollider = GetComponent<Collider2D>();
	}

	private void Update()
	{
		// Check if there are any mobs left
		bool hasMobs = turnManager.actors.Any(actor => actor is Mob);

		// If there are no mobs, unlock the door
		if (!hasMobs)
		{
			Unlock();
		}
		else
		{
			Lock();
		}
	}

	public void Unlock()
	{
		// Logic to unlock the door
		doorCollider.isTrigger = true;
	}

	public void Lock()
	{
		// Logic to lock the door
		doorCollider.isTrigger = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && !turnManager.actors.Any(actor => actor is Mob))
		{
			RoomManager.Instance.GenerateNewRoom(orientation);
			Destroy(gameObject);
		}
	}
}
