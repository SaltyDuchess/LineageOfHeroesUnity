using UnityEngine;

public class BeastlyBite : MonoBehaviour, Spells
{
    float healPercentage = 0.5f;
    [SerializeField] public Sprite uiElement { get; set; }
    public string displayName { get; set; }
    public int cooldown { get; set; }
    public int levelRequirement { get; set; }
    public string descriptionLong { get; set; }
    public bool instantCast { get; set; }
    public float abilityPowerCost { get; set; }
    public bool isCastable { get; set; }
    public Creature targetedEnemy { get; set; }
    public float physDamageModifier { get; set; }
    public float magicDamageModifier { get; set; }
    public float DOT { get; set; }
    public int DOTTurns { get; set; }
    public int stunTurns { get; set; }
    public CalcCritAndDamage calcCritAndDamage { get; set; }

    private void Awake()
    {
        displayName = "Beastly Bite";
        uiElement = uiElement;
        levelRequirement = 2;
        abilityPowerCost = 33;
        physDamageModifier = 0.45f;
        descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% additional physical damage and heals for {healPercentage * 100}% of damage dealt after enemy damage reduction.";
    }

    // Add Beastly Bite-specific functionality here
    public void ExecuteBeastlyBite(Creature attacker, Creature defender)
    {
        float damage;

        attacker.currentAbilityPool -= abilityPowerCost;

        damage = attacker.GetDamageValue() + attacker.GetDamageValue() * physDamageModifier;
        damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

        damage -= damage * defender.physDamageResist;

        defender.currentHealth -= damage;

        attacker.currentHealth += damage * healPercentage;

        if (attacker.currentHealth > attacker.healthPool)
        {
            attacker.currentHealth = attacker.healthPool;
        }

        cooldown = 3;
    }
}
