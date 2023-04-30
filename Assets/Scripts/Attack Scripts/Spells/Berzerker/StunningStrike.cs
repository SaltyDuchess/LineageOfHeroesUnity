using UnityEngine;

public class StunningStrike : Spells
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
			displayName = "Stunning Strike";
    	levelRequirement = 3;
    	abilityPowerCost = 20;
    	physDamageModifier = 0;
    	stunTurns = 2;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Stuns target for {stunTurns} turns";
		}

    public void ExecuteStunningStrike(Creature attacker, Creature defender)
    {
        float damage;

        attacker.currentAbilityPool -= abilityPowerCost;

        damage = attacker.GetDamageValue() + attacker.GetDamageValue() * physDamageModifier;
        damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

        damage -= damage * defender.physDamageResist;

        defender.currentHealth -= damage;

        defender.speedPool -= stunTurns * 100;

        cooldown = 8;
    }
}
