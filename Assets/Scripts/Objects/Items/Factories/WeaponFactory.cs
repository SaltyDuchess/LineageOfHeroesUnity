using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.WeaponType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Weapon
{
public class WeaponFactory : MonoBehaviour
{
	[SerializeField] private LineageOfHeroes.Items.Weapon damagedDaggerPrefab;
	[SerializeField] private LineageOfHeroes.Items.Weapon smallSwordPrefab;

    public EquipmentBase CreateWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.DamagedDagger:
                return Instantiate(damagedDaggerPrefab);
						case WeaponType.SmallSword:
                return Instantiate(smallSwordPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {weaponType}");
        }
    }
}
}
