using UnityEngine;

public class InstantImmolation : MonoBehaviour, Spells
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
			displayName = "Instant Immolation";
			levelRequirement = 4;
			abilityPowerCost = 0;
			physDamageModifier = 0;
			descriptionLong = $"{displayName}\nCost - 100% of Stamina\nRequired Level - {levelRequirement}\nDescription - Instantly kills enemy of equal or lesser level";
		}

    public void ExecuteInstantImmolation(Creature attacker, Creature defender)
    {
        if (attacker.currentLevel >= defender.currentLevel)
        {
            attacker.currentAbilityPool -= attacker.abilityPowerPool;
            defender.currentHealth = 0;
            cooldown = 20;
        }
    }
}
