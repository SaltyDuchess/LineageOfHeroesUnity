using System.Collections.Generic;
using LineageOfHeroes.Items;
using UnityEngine;

namespace LineageOfHeroes.LootSystem
{
	[CreateAssetMenu(fileName = "LootTable", menuName = "Loot/LootTable", order = 1)]
	public class LootTable : ScriptableObject
	{
			[SerializeField] private Rarity tableRarity;
			[SerializeField] private List<IItem.ItemDrop> itemDrops;

			public Rarity TableRarity => tableRarity;
			public List<IItem.ItemDrop> ItemDrops => itemDrops;
	}
}
