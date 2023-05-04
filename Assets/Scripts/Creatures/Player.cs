using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Items;
using UnityEngine;

public class Player : MonoBehaviour, ICreature
{
	public CreatureStats creatureStats = new CreatureStats();
	public bool IsPlayer => true;
	[SerializeField] private CharacterClass characterClass;
	public int XPToNextLevel { get; set; } = 10;
	public IAbility queuedAbility { get; set; } = null;
	public SpellManager playerSpellbook { get; set; } = null;
	public IClass playerClass { get; set; } = null;
	public PlayerInventory inventory { get; set; } = null;
	public int previousRoom { get; set; } = -1;
	public string displayName { get; set; } = "A mob";
	public string mobDescription { get; set; } = "Ya forgot a mob description";
	public float speedPool { get; set; } = 100;

	private void Awake()
	{
		// Initialize the player class using the assigned character class ScriptableObject
		playerClass = characterClass;

		// Modify player stats based on the chosen class
		characterClass.ModifyPlayerStats(this);
	}

	    public void OnTurn()
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
}
