using System.Collections.Generic;
using UnityEngine;
using static LineageOfHeroes.Items.IItem;

namespace LineageOfHeroes.LootSystem
{
	[CreateAssetMenu(fileName = "LootTable", menuName = "Loot/LootTable", order = 1)]
	public class LootTable : ScriptableObject
	{
			[SerializeField] private Rarity tableRarity;
			[SerializeField] private List<ItemDrop> itemDrops;

			public Rarity TableRarity => tableRarity;
			public List<ItemDrop> ItemDrops => itemDrops;
	}
}
