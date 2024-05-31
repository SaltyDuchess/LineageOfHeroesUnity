using System;
using System.Collections.Generic;
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
		private Dictionary<ItemType, Func<string, EquipmentBase>> factoryMap;

		[SerializeField] private WeaponFactory weaponFactory;
		[SerializeField] private BootFactory bootFactory;
		[SerializeField] private CapeFactory capeFactory;
		[SerializeField] private ChestFactory chestFactory;
		[SerializeField] private GauntletFactory gauntletFactory;
		[SerializeField] private HelmetFactory helmetFactory;
		[SerializeField] private RingFactory ringFactory;
		[SerializeField] private ShoulderFactory shoulderFactory;

		private void Awake()
		{
			factoryMap = new Dictionary<ItemType, Func<string, EquipmentBase>>
				{
					{ ItemType.Weapon, formattedItemName => CreateItem<WeaponType>(formattedItemName, weaponFactory.CreateWeapon) },
					{ ItemType.Boot, formattedItemName => CreateItem<BootType>(formattedItemName, bootFactory.CreateBoot) },
					{ ItemType.Cape, formattedItemName => CreateItem<CapeType>(formattedItemName, capeFactory.CreateCape) },
					{ ItemType.Chest, formattedItemName => CreateItem<ChestType>(formattedItemName, chestFactory.CreateChest) },
					{ ItemType.Gauntlet, formattedItemName => CreateItem<GauntletType>(formattedItemName, gauntletFactory.CreateGauntlet) },
					{ ItemType.Helmet, formattedItemName => CreateItem<HelmetType>(formattedItemName, helmetFactory.CreateHelmet) },
					{ ItemType.Ring, formattedItemName => CreateItem<RingType>(formattedItemName, ringFactory.CreateRing) },
					{ ItemType.Shoulder, formattedItemName => CreateItem<ShoulderType>(formattedItemName, shoulderFactory.CreateShoulder) }
				};
		}

		public EquipmentBase CreateItem(EquipmentData equipmentData)
		{
			string formattedItemName = equipmentData.displayName.Replace(" ", "");
			if (factoryMap.TryGetValue(equipmentData.itemType, out var factoryMethod))
			{
				return factoryMethod(formattedItemName);
			}
			throw new ArgumentException($"Invalid item type: {equipmentData.itemType}");
		}

		private EquipmentBase CreateItem<T>(string formattedItemName, Func<T, EquipmentBase> createMethod) where T : struct, Enum
		{
			if (Enum.TryParse(formattedItemName, out T itemType))
			{
				return createMethod(itemType);
			}
			throw new ArgumentException($"Expected a {typeof(T).Name} instead received {formattedItemName}");
		}
	}
}