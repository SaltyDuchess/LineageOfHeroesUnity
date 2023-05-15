using System.Collections.Generic;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PlayerInventory: MonoBehaviour
	{
			public List<EquipmentData> InventoryList { get; set; }

			public PlayerInventory()
			{
					InventoryList = new List<EquipmentData>();
			}
	}
}
