using UnityEngine;

public class Ability : MonoBehaviour
{
    public string displayName = null;
    public Sprite uiElement = null;
    public int cooldown = 0;
    public int levelRequirement = 0;
    public string descriptionLong = "You forgot to add a description, fucking idiot";
    public bool instantCast = false;
    public float abilityPowerCost = 0;
    public bool isCastable = false;
    public Creature targetedEnemy = null;

    // Add ability-specific functionality here.
}