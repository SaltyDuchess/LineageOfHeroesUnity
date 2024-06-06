using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
	public CreatureLibrary masterCreatureLibrary;
	public EnemyManager enemyManager;
	public TurnManager turnManager;
	private Player player;

	void Awake()
	{
		player = FindObjectOfType<Player>();
		enemyManager = FindObjectOfType<EnemyManager>();
		turnManager = FindObjectOfType<TurnManager>();
	}

	public void SpawnEnemiesInRoom(Room room)
	{
		enemyManager.SetCurrentRoom(room);
		int totalMobLevel = 0;
		while (totalMobLevel < player.currentLevel + 1)
		{
			Mob mobToSpawn = masterCreatureLibrary.SelectMobForLevel(player.currentLevel);
			SpawnMobInRoom(mobToSpawn, room);
			totalMobLevel += mobToSpawn.creatureData.stats.currentLevel;
		}
	}

	void SpawnMobInRoom(Mob mob, Room room)
	{
		Vector3 randomPosition;
		do
		{
			randomPosition = new Vector3(
					Random.Range(room.transform.position.x - room.roomSize.x / 2 + 3, room.transform.position.x + room.roomSize.x / 2 - 3),
					Random.Range(room.transform.position.y - room.roomSize.y / 2 + 3, room.transform.position.y + room.roomSize.y / 2 - 3),
					0);
		} while (Vector3.Distance(randomPosition, player.transform.position) < 3);

		Mob mobInstance = Instantiate(mob, randomPosition, Quaternion.identity, room.transform);
		enemyManager.RegisterEnemy(mobInstance);
		turnManager.AddActor(mobInstance);
	}
}
