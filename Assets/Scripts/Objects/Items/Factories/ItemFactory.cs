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
using UnityEngine;

namespace LineageOfHeroes.ItemFactories
{
	public class ItemFactory : MonoBehaviour
	{
		[SerializeField] public WeaponFactory weaponFactory;
		[SerializeField] public BootFactory bootFactory;
		[SerializeField] public CapeFactory capeFactory;
		[SerializeField] public ChestFactory chestFactory;
		[SerializeField] public GauntletFactory gauntletFactory;
		[SerializeField] public HelmetFactory helmetFactory;
		[SerializeField] public RingFactory ringFactory;
		[SerializeField] public ShoulderFactory shoulderFactory;
    public EquipmentBase CreateItem(EquipmentData equipmentData, object specificType = null)
    {
			string formattedItemName = equipmentData.displayName.Replace(" ", "");
        switch (equipmentData.itemType)
        {
            case ItemType.Weapon:
                if (!Enum.TryParse(formattedItemName, out WeaponType weaponType)) throw new ArgumentException("Expected a WeaponType");
                return weaponFactory.CreateWeapon(weaponType);
            case ItemType.Boot:
                if (!Enum.TryParse(formattedItemName, out BootType bootType)) throw new ArgumentException("Expected a BootType");
                return bootFactory.CreateBoot(bootType);
            case ItemType.Cape:
                if (!Enum.TryParse(formattedItemName, out CapeType capeType)) throw new ArgumentException("Expected a CapeType");
                return capeFactory.CreateCape(capeType);
            case ItemType.Chest:
                if (!Enum.TryParse(formattedItemName, out ChestType chestType)) throw new ArgumentException("Expected a ChestType");
                return chestFactory.CreateChest(chestType);
            case ItemType.Gauntlet:
                if (!Enum.TryParse(formattedItemName, out GauntletType gauntletType)) throw new ArgumentException("Expected a GauntletType");
                return gauntletFactory.CreateGauntlet(gauntletType);
            case ItemType.Helmet:
                if (!Enum.TryParse(formattedItemName, out HelmetType helmetType)) throw new ArgumentException("Expected a HelmetType");
                return helmetFactory.CreateHelmet(helmetType);
            case ItemType.Ring:
                if (!Enum.TryParse(formattedItemName, out RingType ringType)) throw new ArgumentException("Expected a RingType");
                return ringFactory.CreateRing(ringType);
            case ItemType.Shoulder:
                if (!Enum.TryParse(formattedItemName, out ShoulderType shoulderType)) throw new ArgumentException("Expected a ShoulderType");
                return shoulderFactory.CreateShoulder(shoulderType);
            default:
                throw new ArgumentException($"Invalid item type: {equipmentData.itemType}");
        }
    }
	}
}
