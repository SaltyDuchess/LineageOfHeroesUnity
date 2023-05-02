using System.Collections.Generic;
using LineageOfHeroes.Randomization;

[System.Serializable]
public class Stats
{
	public int currentLevel = 1;
	public float healthPool = 100;
	public float currentHealth = 100;
	public float percentageHealth = 100;
	public float speedPool = 100;
	public float abilityPowerPool = 100;
	public float currentAbilityPool = 100;
	public float percentageAbilityPool = 100;
	public float abilityRegeneration = 1;
	public float dodgeChance = 0;
	public float physDamageResist = 0;
	public float magicDamageResist = 0;
	public float invulnerabilityCharges = 0;
	public float autoAttackRange = 0;
	public float actionSpeedCost = 100;
	public float damageOverTime = 0;
	public float damageOverTimeTurns = 0;
	public int XPValue = 5;
	public List<float> damageRange = new List<float> { 10.5f, 13.75f };
	public float healthRegeneration = 0.5f;
	public float critDamageMultiplier = 1;
	public float critChanceModifier = 0.1f;

	
	public float GetDamageValue()
	{
		return RandomGenerator.Range(damageRange[0], damageRange[1]);
	}
}
