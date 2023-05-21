using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<int> activeEnemies = new List<int>();

    public void RegisterEnemy(Mob enemy)
    {
        activeEnemies.Add(enemy.gameObject.GetInstanceID());
    }

    public void UnregisterEnemy(Mob enemy)
    {
        activeEnemies.Remove(enemy.gameObject.GetInstanceID());

        if (activeEnemies.Count == 0)
        {
            // All enemies have been killed
            SpawnChest();
        }
    }

    private void SpawnChest()
    {
      // Get current room info
			RoomInfo currentRoomInfo = FindObjectOfType<RoomInfo>();

			// Spawn a chest of a rarity equal to the room's rarity
			FindObjectOfType<ChestSpawner>().SpawnChest(currentRoomInfo.roomRarity);
    }
}
