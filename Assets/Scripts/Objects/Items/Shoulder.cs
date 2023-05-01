using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.ShoulderType;

namespace LineageOfHeroes.Items
{
	public abstract class Shoulder : EquipmentBase
	{
		public ShoulderType shoulderType { get; set; }
		[SerializeField] ShoulderData shoulderData;

		new protected virtual void Awake()
		{
			base.Awake();
			shoulderType = shoulderData.shoulderType;
		}
	}
}
