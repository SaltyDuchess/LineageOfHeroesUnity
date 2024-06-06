using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public List<int> activeEnemies = new List<int>();
	private Room currentRoom;

	public void SetCurrentRoom(Room room)
	{
		currentRoom = room;
	}

	public void RegisterEnemy(Mob enemy)
	{
		activeEnemies.Add(enemy.gameObject.GetInstanceID());
	}

	public void UnregisterEnemy(Mob enemy)
	{
		activeEnemies.Remove(enemy.gameObject.GetInstanceID());

		if (activeEnemies.Count == 0 && currentRoom != null)
		{
			// All enemies have been killed
			UnlockDoors();
			SpawnChest(currentRoom.roomRarity);
		}
	}

	private void UnlockDoors()
	{
		// Get all DoorController instances in the scene
		var doors = FindObjectsOfType<DoorController>();
		foreach (var door in doors)
		{
			door.Unlock(); // Assuming DoorController has an Unlock method
		}
	}

	private void SpawnChest(Rarity rarity)
	{
		// Spawn a chest of a rarity equal to the room's rarity
		FindObjectOfType<ChestSpawner>().SpawnChest(rarity, currentRoom);
	}
}
