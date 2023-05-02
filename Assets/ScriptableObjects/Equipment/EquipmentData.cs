using UnityEngine;

public class EquipmentData : ScriptableObject
{
	public StatRange lootDivergance;
	public Rarity itemRarity;
	public Sprite uiElement;
	public EquipmentStats stats = new EquipmentStats();
}
