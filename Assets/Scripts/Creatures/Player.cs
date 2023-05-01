using System.Collections.Generic;
using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Items;
using UnityEngine;

public class Player : MonoBehaviour, ICreature
{
    public int XPToNextLevel { get; set; } = 10;
    public IAbility queuedAbility { get; set; } = null;
    public float healthRegeneration { get; set; } = 0.5f;
    public float critDamageMultiplier { get; set; } = 1;
    public float critChanceModifier { get; set; } = 0.1f;
    public List<float> damageRange { get; set; } = new List<float> { 10.5f, 13.75f };
    public SpellManager playerSpellbook { get; set; } = null;
    public IClass playerClass { get; set; } = null;
    public PlayerInventory inventory { get; set; } = null;
    public int previousRoom { get; set; } = -1;
    public int XPValue { get; set; } = 5;
    public string displayName { get; set; } = "A mob";
    public string mobDescription { get; set; } = "Ya forgot a mob description";
    public int currentLevel { get; set; } = 1;
    public float healthPool { get; set; } = 100;
    public float currentHealth { get; set; } = 100;
    public float percentageHealth { get; set; } = 100;
    public float speedPool { get; set; } = 100;
    public float abilityPowerPool { get; set; } = 100;
    public float currentAbilityPool { get; set; } = 100;
    public float percentageAbilityPool { get; set; } = 100;
    public float abilityRegeneration { get; set; } = 1;
    public float dodgeChance { get; set; } = 0;
    public float physDamageResist { get; set; } = 0;
    public float magicDamageResist { get; set; } = 0;
    public float invulnerabilityCharges { get; set; } = 0;
    public float autoAttackRange { get; set; } = 0;
    public float actionSpeedCost { get; set; } = 100;
    public float damageOverTime { get; set; } = 0;
    public float damageOverTimeTurns { get; set; } = 0;
}
