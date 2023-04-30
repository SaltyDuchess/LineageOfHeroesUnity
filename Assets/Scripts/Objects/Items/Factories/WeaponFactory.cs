using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.WeaponType;

namespace LineageOfHeroes.ItemFactories.Weapon
{
public static class WeaponFactory
{
    public static IItem CreateWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.DamagedDagger:
                return new DamagedDagger();
            case WeaponType.SmallSword:
                return new SmallSword();
            default:
                throw new ArgumentException($"Invalid weapon type: {weaponType}");
        }
    }
}
}
