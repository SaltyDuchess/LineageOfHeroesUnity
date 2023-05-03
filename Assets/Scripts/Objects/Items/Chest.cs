using UnityEngine;
using LineageOfHeroes.ItemTypes.ChestType;

namespace LineageOfHeroes.Items
{
	public class Chest : EquipmentBase
	{
			[SerializeField] ChestData chestData;
			public ChestType chestType { get; set; }

			new protected virtual void Awake()
			{
				base.equipmentData = chestData;
				base.Awake();
				chestType = chestData.chestType;
			}
	}
}
