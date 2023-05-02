using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.WeaponType;

namespace LineageOfHeroes.Items
{
	public class Weapon : EquipmentBase
	{
		public WeaponType weaponType { get; set; }

		new protected virtual void Awake()
		{
			base.Awake();
		}
	}
}
