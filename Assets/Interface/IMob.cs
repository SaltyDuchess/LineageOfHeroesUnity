public interface IMob : ICreature
{
    bool isPlayer { get; }
    int level { get; set; }
    float healthPool { get; set; }
    float currentHealth { get; set; }
    float percentageHealth { get; set; }
    int xPValue { get; set; }
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
    string displayName { get; set; }
    string mobDescription { get; set; }
}
