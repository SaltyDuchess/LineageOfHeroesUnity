using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public Vector2Int roomSize;
	public Rarity roomRarity;
	public bool isDefeated;

	private List<GameObject> walls;
	private List<GameObject> doors;

	public void Initialize(Vector2Int size)
	{
		roomSize = size;
		isDefeated = false;
		walls = new List<GameObject>();
		doors = new List<GameObject>();
	}

	public void AddWall(GameObject wall)
	{
		walls.Add(wall);
	}

	public void AddDoor(GameObject door)
	{
		doors.Add(door);
	}

	public void SetDefeated(bool defeated)
	{
		isDefeated = defeated;
	}

	public List<GameObject> GetDoors()
	{
		return doors;
	}

	public List<GameObject> GetWalls()
	{
		return walls;
	}

	public void SpawnContents(GameObject[] spawnableObjects)
	{
		// Example of spawning objects within the room dimensions
		foreach (var obj in spawnableObjects)
		{
			Vector3 spawnPosition = new Vector3(
					Random.Range(-roomSize.x / 2, roomSize.x / 2),
					Random.Range(-roomSize.y / 2, roomSize.y / 2),
					0
			);

			Instantiate(obj, transform.position + spawnPosition, Quaternion.identity, transform);
		}
	}
}
