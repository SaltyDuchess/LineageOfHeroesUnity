using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.HelmetType;

namespace LineageOfHeroes.Items
{
	public abstract class Helmet : EquipmentBase
	{
		[SerializeField] HelmetData helmetData;
		public HelmetType helmetType { get; set; }

			new protected virtual void Awake()
			{
				base.Awake();
				helmetType = helmetData.helmetType;
			}
	}
}
