using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Creature : Level, ICritStats
{
    // Override currentLevel property from Level class
    public new int currentLevel = 1;

    public float healthPool = 100;
    public float currentHealth = 100;
    public float percentageHealth = 100;
    public float speedPool = 100;
    public IAbility queuedAbility = null;
    public float abilityPowerPool = 100;
    public float currentAbilityPool = 100;
    public float percentageAbilityPool = 100;
    public float abilityRegeneration = 1;
    public float healthRegeneration = 0.2f;
    public float critChanceModifier { get; set; } = 0;
    public float critDamageMultiplier { get; set; } = 0;
    public List<float> damageRange = new List<float>(2);
    public float dodgeChance = 0;
    public float physDamageResist = 0;
    public float magicDamageResist = 0;
    public float invulnerabilityCharges = 0;
    public float autoAttackRange = 0;
    public float actionSpeedCost = 100;
    public float damageOverTime = 0;
    public float damageOverTimeTurns = 0;
    public int[] mobLevelArray = new int[0];

    // Add creature-specific functionality here.
		public float GetDamageValue()
		{
			return Random.Range(damageRange[0], damageRange[1]);
		}
}