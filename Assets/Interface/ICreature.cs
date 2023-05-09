using UnityEngine;

public interface ICreature
{
    void OnTurn();
		public bool TryAttack(Creature target);

    float speedPool { get; set; }
    float abilityPowerPool { get; set; }
    float currentAbilityPool { get; set; }
    float percentageAbilityPool { get; set; }
    float abilityRegeneration { get; set; }
    float dodgeChance { get; set; }
    float physDamageResist { get; set; }
    float magicDamageResist { get; set; }
    float invulnerabilityCharges { get; set; }
    float autoAttackRange { get; set; }
    float actionSpeedCost { get; set; }
    float damageOverTime { get; set; }
    int damageOverTimeTurns { get; set; }
    StatRange damageRange { get; set; }
    float healthRegeneration { get; set; }
    float critDamageMultiplier { get; set; }
    float critChanceModifier { get; set; }
    int currentLevel { get; set; }
    float healthPool { get; set; }
    float currentHealth { get; set; }
    float percentageHealth { get; set; }
    int XPValue { get; set; }
		GameObject healthBarObject { get; set; }
}