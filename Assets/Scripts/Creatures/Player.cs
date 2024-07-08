using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Items;
using UnityEngine;

public class Player : Creature
{
	[SerializeField] public int abilityPoints { get; set; }
	public CharacterClass playerClassPrefab;
	public CharacterClass playerClass { get; set; }
	public GlobalEffectsManager globalEffectsManager { get; set; }
	public int XPToNextLevel { get; set; } = 5;
	public PlayerInventory inventory { get; set; } = null;
	public int previousRoom { get; set; } = -1;
	public string displayName { get; set; }
	public string mobDescription { get; set; }
	public int currentXP { get; set; } = 0;
	public bool IsTakingTurn { get; private set; } = false;
	private float baseHealthPool;
	private float equipmentHealthPool;

	private void OnEnable()
	{
		GlobalEffectsManager.Instance.OnPlayerPercentageHPBoostChanged += UpdateHealthBasedOnBoostValueUpdate;
	}

	private void OnDisable()
	{
		GlobalEffectsManager.Instance.OnPlayerPercentageHPBoostChanged -= UpdateHealthBasedOnBoostValueUpdate;
	}

	new private void Awake()
	{
		base.Awake();
		playerClass = Instantiate(playerClassPrefab, transform);
		IsPlayer = true;
		baseHealthPool = healthPool;
		globalEffectsManager = FindObjectOfType<GlobalEffectsManager>();
		// Modify player stats based on the chosen class
		//playerClass.ModifyPlayerStats(this);
	}

	public override void OnTurn()
	{
		// Enable player input
		currentSpeedPool += 100;
		GetComponent<PlayerMovement>().enabled = true;
		AbilityManager.Instance.ApplySustainedSpells(this);
	}

	public void TakeAction()
	{
		currentSpeedPool -= actionSpeedCost;
		GetComponent<PlayerMovement>().enabled = false;
		TurnManager turnManager = FindObjectOfType<TurnManager>();
		if (currentSpeedPool < 100)
		{
			turnManager.NextTurn();
		}
	}

	public void AddXP(int amount)
	{
		currentXP += amount;
		while (XPToNextLevel <= currentXP)
		{
			abilityPoints++;
			currentLevel++;
			XPToNextLevel *= 2;
		}
	}

	public void UpdateHealthPoolFromEquipment(float newEquipmentHealthPoolChange)
	{
		equipmentHealthPool += newEquipmentHealthPoolChange;
		float newHealthPoolBeforePercentages = baseHealthPool + equipmentHealthPool;
		float newHealthPool = newHealthPoolBeforePercentages * (1 + globalEffectsManager.PlayerPercentageHPBoost);
		healthPool = newHealthPool;
		Debug.Log($"Player health updated. New health pool: {healthPool}, current health: {currentHealth}");
	}

	private void UpdateHealthBasedOnBoostValueUpdate(float percentageBoost)
	{
		float newHealthPool = healthPool * (1 + percentageBoost);
		currentHealth += newHealthPool - healthPool;
		healthPool = newHealthPool;
		Debug.Log($"Player health updated. New health pool: {healthPool}, current health: {currentHealth}");
	}
}
