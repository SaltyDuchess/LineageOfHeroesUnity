[System.Serializable]
public class Stats
{
	public float speedPool;
	public float abilityPowerPool;
	public float currentAbilityPool;
	public float percentageAbilityPool;
	public float abilityRegeneration;
	public float dodgeChance;
	public float physDamageResist;
	public float magicDamageResist;
	public float invulnerabilityCharges;
	public float autoAttackRange;
	public float actionSpeedCost;
	public float damageOverTime;
	public int damageOverTimeTurns;
	public StatRange damageRange;
	public float healthRegeneration;
	public float critDamageMultiplier;
	public float critChanceModifier;

	
	public float GetDamageValue()
	{
		return damageRange.GetRandomValue();
	}
}
