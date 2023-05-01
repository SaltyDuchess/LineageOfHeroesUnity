using UnityEngine;

public interface IAbility
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
    public ICreature targetedEnemy { get; set; }
}