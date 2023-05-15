using LineageOfHeroes.ItemTypes;
using UnityEngine;

public class EquipmentData : ScriptableObject
{
	public ItemType itemType;
	public StatRange lootDivergance;
	public Rarity itemRarity;
	public Sprite uiElement;
	public EquipmentStats stats = new EquipmentStats();
	public string displayName;
	public string descriptionLong;
}
