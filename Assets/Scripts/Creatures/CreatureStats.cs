[System.Serializable]
public class CreatureStats : Stats
{
	public int currentLevel = 1;
	public float healthPool = 100;
	public float currentHealth = 100;
	public float percentageHealth = 100;
	public int XPValue = 5;

	// Constructor
	public CreatureStats()
	{
		speedPool = 100;
		abilityPowerPool = 100;
		currentAbilityPool = 100;
		percentageAbilityPool = 100;
		abilityRegeneration = 1;
		dodgeChance = 0;
		physDamageResist = 0;
		magicDamageResist = 0;
		invulnerabilityCharges = 0;
		autoAttackRange = 0;
		actionSpeedCost = 100;
		damageOverTime = 0;
		damageOverTimeTurns = 0;
		healthRegeneration = 0.5f;
		critDamageMultiplier = 1;
		critChanceModifier = 0.1f;
	}
}
