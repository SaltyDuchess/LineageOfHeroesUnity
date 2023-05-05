using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Items;
using UnityEngine;

public class Player : Creature
{
	[SerializeField] private CharacterClass characterClass;
	public int XPToNextLevel { get; set; } = 10;
	public SpellManager playerSpellbook { get; set; } = null;
	public IClass playerClass { get; set; } = null;
	public PlayerInventory inventory { get; set; } = null;
	public int previousRoom { get; set; } = -1;
	public string displayName { get; set; }
	public string mobDescription { get; set; }
	public int abilityPoints { get; set; }

	new private void Awake()
	{
		base.Awake();
		IsPlayer = true;
		// Initialize the player class using the assigned character class ScriptableObject
		playerClass = characterClass;

		// Modify player stats based on the chosen class
		characterClass.ModifyPlayerStats(this);
	}

	new public void OnTurn()
	{
		// Enable player input
		GetComponent<PlayerMovement>().enabled = true;
	}

	public void EndTurn()
	{
		GetComponent<PlayerMovement>().enabled = false;
		speedPool -= 100;
		TurnManager turnManager = FindObjectOfType<TurnManager>();
		if (speedPool <= 100)
		{
			turnManager.NextTurn();
		}
	}

	public void AddXP(int amount)
	{
		XPToNextLevel -= amount;
		if (XPToNextLevel <= 0)
		{
			abilityPoints++;
			currentLevel++;
			XPToNextLevel = 100;
		}
	}
}
