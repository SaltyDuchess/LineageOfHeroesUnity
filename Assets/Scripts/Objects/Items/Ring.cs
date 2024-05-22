using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.RingType;

namespace LineageOfHeroes.Items
{
	public class Ring : EquipmentBase
	{
		public RingType ringType { get; set; }
		[SerializeField] RingData ringData;

		new protected virtual void Awake()
		{
			base.equipmentData = ringData;
			type = ItemType.Ring;
			ringType = ringData.ringType;
			base.Awake();
		}
	}
}
