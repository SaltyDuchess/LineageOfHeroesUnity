using System.Collections.Generic;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PlayerInventory: MonoBehaviour
	{
			public List<IItem> InventoryList { get; set; }

			public PlayerInventory()
			{
					InventoryList = new List<IItem>();
			}
	}
}
