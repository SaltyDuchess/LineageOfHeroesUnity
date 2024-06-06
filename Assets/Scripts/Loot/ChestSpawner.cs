using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChestSpawner : MonoBehaviour
{
	public List<Chest> chests;

	public void SpawnChest(Rarity rarity, Room room)
	{
		List<Chest> possibleChests = chests.Where(chest => chest.lootTable.TableRarity == rarity).ToList();
		if (possibleChests.Count == 0)
		{
			Debug.LogError("No chests of rarity " + rarity + " available to spawn!");
			return;
		}

		Chest chestToSpawn = possibleChests[Random.Range(0, possibleChests.Count)];
		Vector3 spawnPosition;

		do
		{
			spawnPosition = new Vector3(
					Random.Range(room.transform.position.x - room.roomSize.x / 2 + 3, room.transform.position.x + room.roomSize.x / 2 - 3),
					Random.Range(room.transform.position.y - room.roomSize.y / 2 + 3, room.transform.position.y + room.roomSize.y / 2 - 3),
					0);
		} while (Vector3.Distance(spawnPosition, FindObjectOfType<Player>().transform.position) < 3);

		Instantiate(chestToSpawn, spawnPosition, Quaternion.identity, room.transform);
	}
}
