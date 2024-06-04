using UnityEngine;

public class DoorController : MonoBehaviour
{
	public enum DoorOrientation { North, South, East, West }
	public DoorOrientation orientation;

	public void Unlock()
	{
		// Logic to unlock the door
		// This could involve changing the door's animation state, disabling a collider, etc.
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			RoomManager.Instance.GenerateNewRoom(orientation);
			Destroy(gameObject);
		}
	}
}
