using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Items;
using UnityEngine;

public class Player : Creature
{
	[SerializeField] public int abilityPoints { get; set; }
	public CharacterClass playerClassPrefab;
	public CharacterClass playerClass { get; set; }
	public int XPToNextLevel { get; set; } = 5;
	public PlayerInventory inventory { get; set; } = null;
	public int previousRoom { get; set; } = -1;
	public string displayName { get; set; }
	public string mobDescription { get; set; }
	public int currentXP { get; set; } = 0;

	new private void Awake()
	{
		base.Awake();
		playerClass = Instantiate(playerClassPrefab, transform);
		IsPlayer = true;
		// Modify player stats based on the chosen class
		//playerClass.ModifyPlayerStats(this);
	}

	new public void OnTurn()
	{
		// Enable player input
		GetComponent<PlayerMovement>().enabled = true;
	}

	public void EndTurn()
	{
		GetComponent<PlayerMovement>().enabled = false;
		TurnManager turnManager = FindObjectOfType<TurnManager>();
		if (speedPool <= 100)
		{
			turnManager.NextTurn();
		}
	}

	public void AddXP(int amount)
	{
		currentXP += amount;
		if (XPToNextLevel <= currentXP)
		{
			abilityPoints++;
			currentLevel++;
			XPToNextLevel *= 2;
		}
	}
}
