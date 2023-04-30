using System.Collections.Generic;

namespace LineageOfHeroes.Items
{
	public class PlayerInventory
	{
			public List<IItem> InventoryList { get; set; }

			public PlayerInventory()
			{
					InventoryList = new List<IItem>();
			}
	}
}
