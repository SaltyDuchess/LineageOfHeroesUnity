using System.Collections.Generic;
using System.Linq;
using LineageOfHeroes.Items;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.LootSystem
{
	public class LootManager : MonoBehaviour
	{
		public void GenerateLootFromTable(LootTable lootTable, PlayerInventory playerInventory)
		{
			Rarity chestRarity = lootTable.TableRarity;
			List<EquipmentBase> allItems = lootTable.ItemDrops.Select(drop => drop.item).ToList();
			List<ConsumableBase> allConsumables = lootTable.ConsumableDrops.Select(drop => drop.consumable).ToList();
			// You can now use the existing GenerateLoot method with the modified arguments
			GenerateLoot(chestRarity, allItems, allConsumables, playerInventory);
		}

		public void GenerateLoot(Rarity chestRarity, List<EquipmentBase> allEquipment, List<ConsumableBase> allConsumables, PlayerInventory playerInventory)
		{
			// Example: Filter items with the same or higher rarity than the chest
			List<EquipmentBase> eligibleEquipment = allEquipment.Where(item => item.equipmentData.itemRarity <= chestRarity).ToList();
			List<ConsumableBase> eligibleConsumables = allConsumables.Where(consumable => consumable.consumableData.consumableRarity <= chestRarity).ToList();

			// Example: Add a higher rarity item with a certain chance (e.g., 10%)
			if (RandomGenerator.Range(0, 100) < 5 && chestRarity < Rarity.Legendary)
			{
				List<EquipmentBase> higherRarityEquipment = allEquipment.Where(item => item.itemRarity == chestRarity + 1).ToList();
				List<ConsumableBase> higherRarityConsumables = allConsumables.Where(consumable => consumable.consumableData.consumableRarity == chestRarity + 1).ToList();
				if (higherRarityEquipment.Count > 0)
				{
					EquipmentData higherRarityItem = higherRarityEquipment[RandomGenerator.Range(0, higherRarityEquipment.Count)].equipmentData;
					playerInventory.EquipmentList.Add(higherRarityItem);
				}
				else if (higherRarityConsumables.Count > 0)
				{
					ConsumableData higherRarityConsumable = higherRarityConsumables[RandomGenerator.Range(0, higherRarityConsumables.Count)].consumableData;
					playerInventory.ConsumableList.Add(higherRarityConsumable);
				}
			}

			// Example: Add 3 random items from the eligible items
			for (int i = 0; i < 13; i++)
			{
				if (eligibleEquipment.Count > 0)
				{
					EquipmentData randomItem = eligibleEquipment[RandomGenerator.Range(0, eligibleEquipment.Count)].equipmentData;
					playerInventory.EquipmentList.Add(randomItem);
					Debug.Log($"Looted  {randomItem.itemType} {randomItem.displayName}");
				}
			}

			// Example: Add 2 random consumables from the eligible consumables
			for (int i = 0; i < 2; i++)
			{
				if (eligibleConsumables.Count > 0)
				{
					ConsumableData randomConsumable = eligibleConsumables[RandomGenerator.Range(0, eligibleConsumables.Count)].consumableData;
					Debug.Log($"Looted  {randomConsumable.consumableType} {randomConsumable.displayName}");
					playerInventory.AddConsumable(randomConsumable);
				}
			}
		}
	}
}
