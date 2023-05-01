using UnityEngine;
using LineageOfHeroes.ItemTypes.ChestType;

namespace LineageOfHeroes.Items
{
	public abstract class Chest : EquipmentBase
	{
			[SerializeField] ChestData chestData;
			public ChestType chestType { get; set; }

			new protected virtual void Awake()
			{
				base.Awake();
				chestType = chestData.chestType;
			}
	}
}
