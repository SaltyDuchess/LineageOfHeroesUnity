using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.ShoulderType;

namespace LineageOfHeroes.Items
{
	public class Shoulder : EquipmentBase
	{
		public ShoulderType shoulderType { get; set; }
		[SerializeField] ShoulderData shoulderData;

		new protected virtual void Awake()
		{
			base.equipmentData = shoulderData;
			type = ItemType.Shoulder;
			shoulderType = shoulderData.shoulderType;
			base.Awake();
		}
	}
}
