using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    public string displayName;
    public Sprite uiElement;
    public int levelRequirement;
    public float abilityPowerCost;
    public int cooldown;
    public bool instantCast;
    public string descriptionLong;
}
