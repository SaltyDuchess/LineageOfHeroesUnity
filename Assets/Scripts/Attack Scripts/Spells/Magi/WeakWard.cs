using UnityEngine;

public class WeakWard : MonoBehaviour, Spells
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
			displayName = "Weak Ward";
    	levelRequirement = 2;
    	abilityPowerCost = 14;
    	instantCast = true;
			descriptionLong = $"{displayName}\nCost - {abilityPowerCost} Stamina\nRequired Level - {levelRequirement}\nDescription - Makes you invulnerable to the next attack.\nDoes not end your turn";
		}

    public void WeakWardScript(Creature castingCreature)
    {
        castingCreature.currentAbilityPool -= abilityPowerCost;

        if (castingCreature.invulnerabilityCharges == 0)
        {
            castingCreature.invulnerabilityCharges += 1;
        }

        cooldown = 10;
        castingCreature.queuedAbility = null;
    }
}
