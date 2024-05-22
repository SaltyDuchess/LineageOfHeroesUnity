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
		[SerializeField] protected WeaponData weaponData;

		new protected virtual void Awake()
		{
			base.equipmentData = weaponData;
			type = ItemType.Weapon;
			weaponType = weaponData.weaponType;
			base.Awake();
		}
	}
}
