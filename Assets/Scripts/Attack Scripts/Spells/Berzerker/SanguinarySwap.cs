using UnityEngine;

public class SanguinarySwap : MonoBehaviour, Spells
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
			displayName = "Sanguinary Swap";
   		levelRequirement = 2;
			instantCast = true;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Swaps your percentage health and your percentage stamina.\nDoes not end your turn";
		}

    public void ExecuteSanguinarySwap(Creature castingCreature)
    {
        float hp = castingCreature.percentageHealth;
        float ap = castingCreature.percentageAbilityPool;

        castingCreature.currentHealth = (ap / 100 * castingCreature.healthPool);
        castingCreature.currentAbilityPool = (hp / 100 * castingCreature.abilityPowerPool);

        cooldown = 10;

        castingCreature.queuedAbility = null;
    }
}
