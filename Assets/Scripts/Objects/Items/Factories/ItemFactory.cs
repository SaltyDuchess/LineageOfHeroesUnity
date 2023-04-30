using System;
using LineageOfHeroes.ItemFactories.Boot;
using LineageOfHeroes.ItemFactories.Cape;
using LineageOfHeroes.ItemFactories.Chest;
using LineageOfHeroes.ItemFactories.Gauntlet;
using LineageOfHeroes.ItemFactories.Helmet;
using LineageOfHeroes.ItemFactories.Ring;
using LineageOfHeroes.ItemFactories.Shoulder;
using LineageOfHeroes.ItemFactories.Weapon;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.BootType;
using LineageOfHeroes.ItemTypes.CapeType;
using LineageOfHeroes.ItemTypes.ChestType;
using LineageOfHeroes.ItemTypes.GauntletType;
using LineageOfHeroes.ItemTypes.HelmetType;
using LineageOfHeroes.ItemTypes.RingType;
using LineageOfHeroes.ItemTypes.ShoulderType;
using LineageOfHeroes.ItemTypes.WeaponType;

namespace LineageOfHeroes.ItemFactories
{
	public class ItemFactory
	{
    public IItem CreateItem(ItemType itemType, object specificType = null)
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                if (specificType is not WeaponType weaponType) throw new ArgumentException("Expected a WeaponType");
                return WeaponFactory.CreateWeapon(weaponType);
            case ItemType.Boot:
                if (specificType is not BootType bootType) throw new ArgumentException("Expected a BootType");
                return BootFactory.CreateBoot(bootType);
            case ItemType.Cape:
                if (specificType is not CapeType capeType) throw new ArgumentException("Expected a CapeType");
                return CapeFactory.CreateCape(capeType);
            case ItemType.Chest:
                if (specificType is not ChestType chestType) throw new ArgumentException("Expected a ChestType");
                return ChestFactory.CreateChest(chestType);
            case ItemType.Gauntlet:
                if (specificType is not GauntletType gauntletType) throw new ArgumentException("Expected a GauntletType");
                return GauntletFactory.CreateGauntlet(gauntletType);
            case ItemType.Helmet:
                if (specificType is not HelmetType helmetType) throw new ArgumentException("Expected a HelmetType");
                return HelmetFactory.CreateHelmet(helmetType);
            case ItemType.Ring:
                if (specificType is not RingType ringType) throw new ArgumentException("Expected a RingType");
                return RingFactory.CreateRing(ringType);
            case ItemType.Shoulder:
                if (specificType is not ShoulderType shoulderType) throw new ArgumentException("Expected a ShoulderType");
                return ShoulderFactory.CreateShoulder(shoulderType);
            default:
                throw new ArgumentException($"Invalid item type: {itemType}");
        }
    }
	}
}
