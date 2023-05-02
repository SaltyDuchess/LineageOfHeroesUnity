using UnityEngine;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;

public class Creature : MonoBehaviour
{
	public virtual bool IsPlayer => false;
	public IAbility queuedAbility { get; set; } = null;
	public Stats stats = new Stats();
	// Add any other MonoBehaviour-specific methods and properties here, if necessary.
}
