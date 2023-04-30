using UnityEngine;

public class FatalFinish : MonoBehaviour, Spells
{
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
    	levelRequirement = 3;
    	abilityPowerCost = 30f;
    	physDamageModifier = 0.2f;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% additional physical damage per 10% missing enemy health. If the enemy is killed,\n refills entire stamina pool.";
    	displayName = "Fatal Finish";
    }

	public void ExecuteFatalFinish(Creature attacker, Creature defender)
    {
        float damage;

        attacker.currentAbilityPool -= abilityPowerCost;

        damage = attacker.GetDamageValue() + attacker.GetDamageValue() * (physDamageModifier * ((100 - defender.percentageHealth) / 10));
        damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

        damage -= damage * defender.physDamageResist;

        defender.currentHealth -= damage;

        if (defender.currentHealth <= 0)
        {
            attacker.currentAbilityPool = attacker.abilityPowerPool;
        }

        cooldown = 8;
    }
}
