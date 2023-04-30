using UnityEngine;

public class LivelyLightning : MonoBehaviour, Spells
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
			displayName = "Lively Lightning";
    	levelRequirement = 2;
    	abilityPowerCost = 33;
    	magicDamageModifier = 4;
    	instantCast = true;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to the targeted enemy.";
		}

    public void LivelyLightningScript(Creature castingCreature, Creature defender, bool isPlayerAttack)
    {
        castingCreature.currentAbilityPool -= abilityPowerCost;

        float damage = castingCreature.GetDamageValue() + castingCreature.GetDamageValue() * magicDamageModifier;
        damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

        damage -= damage * defender.magicDamageResist;

        defender.currentHealth -= damage;

        cooldown = 6;
    }
}
