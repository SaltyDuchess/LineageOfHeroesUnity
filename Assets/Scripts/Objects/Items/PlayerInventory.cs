using System.Collections.Generic;

public class PlayerInventory
{
    public List<IItem> InventoryList { get; set; }

    public PlayerInventory()
    {
        InventoryList = new List<IItem>();
    }
}
