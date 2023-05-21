using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ChestSpawner : MonoBehaviour
{
	public List<Chest> chests;

	public void SpawnChest(Rarity rarity)
	{
		List<Chest> possibleChests = chests.Where(chest => chest.lootTable.TableRarity == rarity).ToList();
		if (possibleChests.Count == 0)
		{
			Debug.LogError("No chests of rarity " + rarity + " available to spawn!");
			return;
		}

		Chest chestToSpawn = possibleChests[Random.Range(0, possibleChests.Count)];
		// select a position that is close to the player but not immediately on top of them
		Vector3 position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
		Instantiate(chestToSpawn, position, Quaternion.identity);
	}
}
