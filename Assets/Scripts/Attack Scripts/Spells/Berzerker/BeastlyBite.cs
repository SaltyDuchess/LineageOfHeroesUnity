using UnityEngine;

public class BeastlyBite : Spells
{
    [SerializeField] private Sprite _uiElement;
		[SerializeField] private CalcCritAndDamage calcCritAndDamage;
    float healPercentage = 0.5f;

    private void Awake()
    {
        displayName = "Beastly Bite";
        uiElement = _uiElement;
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
