using UnityEngine;
using LineageOfHeroes.ItemTypes.ChestType;
using LineageOfHeroes.ItemTypes;

namespace LineageOfHeroes.Items
{
	public class Chest : EquipmentBase
	{
			[SerializeField] ChestData chestData;
			public ChestType chestType { get; set; }

			new protected virtual void Awake()
			{
				base.equipmentData = chestData;
				type = ItemType.Chest;
				chestType = chestData.chestType;
				base.Awake();
			}
	}
}
