using UnityEngine;

[CreateAssetMenu(fileName = "NewSpellData", menuName = "ScriptableObjects/SpellData", order = 1)]
public class SpellData : ScriptableObject
{
    public string spellName;
    public Sprite uiElement;
    public int levelRequirement;
    public float abilityPowerCost;
    public string descriptionLong;
		public int cooldown;
		public bool instantCast;
}
