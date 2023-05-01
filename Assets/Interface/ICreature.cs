using System.Collections.Generic;
using LineageOfHeroes.Randomization;

public interface ICreature : ICritStats
{
    public int currentLevel { get; set; }
    public float healthPool { get; set; }
    public float currentHealth { get; set; }
    public float percentageHealth { get; set; }
    public float speedPool { get; set; }
    public IAbility queuedAbility { get; set; }
    public float abilityPowerPool { get; set; }
    public float currentAbilityPool { get; set; }
    public float percentageAbilityPool { get; set; }
    public float abilityRegeneration { get; set; }
    public float healthRegeneration { get; set; }
    public List<float> damageRange { get; set; }
    public float dodgeChance { get; set; }
    public float physDamageResist { get; set; }
    public float magicDamageResist { get; set; }
    public float invulnerabilityCharges { get; set; }
    public float autoAttackRange { get; set; }
    public float actionSpeedCost { get; set; }
    public float damageOverTime { get; set; }
    public float damageOverTimeTurns { get; set; }

    // Add ICreature-specific functionality here.
		public float GetDamageValue()
		{
			return RandomGenerator.Range(damageRange[0], damageRange[1]);
		}
}