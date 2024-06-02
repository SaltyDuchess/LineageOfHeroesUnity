using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureLibrary", menuName = "CreatureLibrary", order = 1)]
public class CreatureLibrary : ScriptableObject
{
	public List<Mob> mobs;

	// Select a mob from the library that is suitable for the given level
	public Mob SelectMobForLevel(int level)
	{
		// Create a list of mobs that are suitable for the given level
		List<Mob> suitableMobs = new List<Mob>();
		foreach (Mob mob in mobs)
		{
			if (mob.creatureData.stats.currentLevel <= level + 1)
			{
				suitableMobs.Add(mob);
			}
		}

		// Select a random mob from the list
		return suitableMobs[Random.Range(0, suitableMobs.Count)];
	}
}
