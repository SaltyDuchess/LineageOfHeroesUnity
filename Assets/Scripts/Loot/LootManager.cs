using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootManager : MonoBehaviour {
	public void GenerateLoot(Rarity chestRarity, List<IItem> allItems, PlayerInventory playerInventory)
	{
			// Example: Filter items with the same or higher rarity than the chest
			List<IItem> eligibleItems = allItems.Where(item => item.itemRarity >= chestRarity).ToList();

			// Example: Add a higher rarity item with a certain chance (e.g., 10%)
			if (UnityEngine.Random.Range(0, 100) < 5 && chestRarity < Rarity.Legendary)
			{
					List<IItem> higherRarityItems = allItems.Where(item => item.itemRarity == chestRarity + 1).ToList();
					if (higherRarityItems.Count > 0)
					{
							IItem higherRarityItem = higherRarityItems[UnityEngine.Random.Range(0, higherRarityItems.Count)];
							playerInventory.InventoryList.Add(higherRarityItem);
					}
			}

			// Example: Add 3 random items from the eligible items
			for (int i = 0; i < 3; i++)
			{
					if (eligibleItems.Count > 0)
					{
							IItem randomItem = eligibleItems[UnityEngine.Random.Range(0, eligibleItems.Count)];
							playerInventory.InventoryList.Add(randomItem);
					}
			}
	}
}
