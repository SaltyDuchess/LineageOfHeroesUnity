using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    public CreatureLibrary masterCreatureLibrary;
    private Player player;

    void Awake()
    {
        // Get player
        player = FindObjectOfType<Player>();

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the script is enabled in this scene
        if (enabled)
        {
          SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        // Continue to spawn mobs while total mob level is less than player's level + 1
        int totalMobLevel = 0;
        while (totalMobLevel < player.currentLevel + 1)
        {
            // Select a suitable mob from the master library
            Mob mobToSpawn = masterCreatureLibrary.SelectMobForLevel(player.currentLevel);

            // Spawn the mob using your preferred method (Instantiate, object pooling, etc.)
            SpawnMob(mobToSpawn);

            // Add the mob's level to the total
            totalMobLevel += mobToSpawn.currentLevel;
        }
    }

		// Spawn the selected mob somewhere in the scene but not too close to the player
    void SpawnMob(Mob mob)
    {
			// Get a random position in the scene
			Vector3 randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

			// Check if the mob is too close to the player
			while (Vector3.Distance(randomPosition, player.transform.position) < 5)
			{
					// Get a new random position
					randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
			}

			// Spawn the mob at the random position
			Instantiate(mob, randomPosition, Quaternion.identity);
		}

    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
