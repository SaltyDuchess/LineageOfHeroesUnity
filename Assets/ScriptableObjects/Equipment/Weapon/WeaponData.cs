using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Equipment/WeaponData", order = 2)]
public class WeaponData : EquipmentData
{
	public LineageOfHeroes.ItemTypes.WeaponType.WeaponType weaponType;
}
