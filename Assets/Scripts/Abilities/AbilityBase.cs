using UnityEngine;

public abstract class AbilityBase : MonoBehaviour, IAbility
{
    public string displayName { get; set; }
    public Sprite uiElement { get; set; }
    public int cooldown { get; set; }
    public int currentCooldown { get; set; }
    public int levelRequirement { get; set; }
    public string descriptionLong { get; set; }
    public bool instantCast { get; set; }
    public float abilityPowerCost { get; set; }
    public bool isCastable { get; set; }
		public bool isSustainedSpell { get; set; }
    public Creature targetedEnemy { get; set; }

    protected virtual void Awake()
    {
			// Set the tooltipText using SetTooltipText method
			TooltipTrigger tooltipTrigger = GetComponent<TooltipTrigger>();
			tooltipTrigger.SetTooltipText(descriptionLong);
    }

		public abstract bool IsCastable(Creature castingCreature = null);

    public abstract void ExecuteAbility(Creature castingCreature = null, Creature defender = null);
}
