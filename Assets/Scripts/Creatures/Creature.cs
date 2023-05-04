using UnityEngine;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;

public class Creature : MonoBehaviour, ICreature
{
	public virtual bool IsPlayer => false;
	public IAbility queuedAbility { get; set; } = null;
	public CreatureStats stats = new CreatureStats();
	public float speedPool { get; set; }
	// Add any other MonoBehaviour-specific methods and properties here, if necessary.

	public void OnTurn()
	{
			// Implement Mob's AI and behavior during their turn
			// Move towards the player or perform an attack if in range
			// ...

			// End the turn
			stats.speedPool -= 100;
			FindObjectOfType<TurnManager>().NextTurn();
	}
}
