using System;
using System.Collections.Generic;
using System.Linq;
using LineageOfHeroes.Items;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.LootSystem
{
	public class LootManager : MonoBehaviour {
		public void GenerateLootFromTable(LootTable lootTable, PlayerInventory playerInventory)
		{
			Rarity chestRarity = lootTable.TableRarity;
			List<EquipmentBase> allItems = lootTable.ItemDrops.Select(drop => drop.item).ToList();

			// You can now use the existing GenerateLoot method with the modified arguments
			GenerateLoot(chestRarity, allItems, playerInventory);
		}

		public void GenerateLoot(Rarity chestRarity, List<EquipmentBase> allItems, PlayerInventory playerInventory)
		{
				// Example: Filter items with the same or higher rarity than the chest
				List<EquipmentBase> eligibleItems = allItems.Where(item => item.itemRarity >= chestRarity).ToList();

				// Example: Add a higher rarity item with a certain chance (e.g., 10%)
				if (RandomGenerator.Range(0, 100) < 5 && chestRarity < Rarity.Legendary)
				{
						List<EquipmentBase> higherRarityItems = allItems.Where(item => item.itemRarity == chestRarity + 1).ToList();
						if (higherRarityItems.Count > 0)
						{
								IItem higherRarityItem = higherRarityItems[RandomGenerator.Range(0, higherRarityItems.Count)];
								playerInventory.InventoryList.Add(higherRarityItem);
						}
				}

				// Example: Add 3 random items from the eligible items
				for (int i = 0; i < 3; i++)
				{
						if (eligibleItems.Count > 0)
						{
								IItem randomItem = eligibleItems[RandomGenerator.Range(0, eligibleItems.Count)];
								playerInventory.InventoryList.Add(randomItem);
						}
				}
		}
	}
}
