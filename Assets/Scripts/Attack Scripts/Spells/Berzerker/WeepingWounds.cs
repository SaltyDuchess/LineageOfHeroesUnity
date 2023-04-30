using UnityEngine;

public class WeepingWound : MonoBehaviour, Spells
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
		[SerializeField] private Creature player;


		private void Awake()
		{
			displayName = "Weeping Wound";
    	levelRequirement = 2;
    	abilityPowerCost = 15;
    	physDamageModifier = -0.1f;
			DOT = (float)(player.GetDamageValue() * .5);
		}

    public void ExecuteWeepingWound(Creature attacker, Creature defender)
    {
        float damage;

        attacker.currentAbilityPool -= abilityPowerCost;

        damage = attacker.GetDamageValue()  + attacker.GetDamageValue() * physDamageModifier;
        damage *= calcCritAndDamage.CalculateCritAndDamage(attacker);

        damage -= damage * defender.physDamageResist;

        defender.currentHealth -= damage;

        defender.damageOverTime = DOT;
        defender.damageOverTimeTurns = DOTTurns;

        cooldown = 3;
    }
}
