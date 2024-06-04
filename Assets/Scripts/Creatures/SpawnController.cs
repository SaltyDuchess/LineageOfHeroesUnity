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
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (enabled)
		{
			SpawnEnemies();
		}
	}

	public void SpawnEnemies()
	{
		int totalMobLevel = 0;
		while (totalMobLevel < player.currentLevel + 1)
		{
			Mob mobToSpawn = masterCreatureLibrary.SelectMobForLevel(player.currentLevel);
			SpawnMob(mobToSpawn);
			totalMobLevel += mobToSpawn.creatureData.stats.currentLevel;
		}
	}

	void SpawnMob(Mob mob)
	{
		Vector3 randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
		while (Vector3.Distance(randomPosition, player.transform.position) < 5)
		{
			randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
		}
		Mob mobInstance = Instantiate(mob, randomPosition, Quaternion.identity);
		enemyManager.RegisterEnemy(mobInstance);
		turnManager.AddActor(mobInstance);
	}

	void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}
