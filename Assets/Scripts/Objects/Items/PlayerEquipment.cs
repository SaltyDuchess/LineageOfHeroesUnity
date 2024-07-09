using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PlayerEquipment : MonoBehaviour
	{
		public Player player;
		public Weapon equippedWeapon = null;
		public Chest equippedChest = null;
		public Gauntlet equippedGauntlet = null;
		public Ring equippedRing = null;
		public Helmet equippedHelmet = null;
		public Boot equippedBoot = null;
		public Shoulder equippedShoulder = null;
		public Cape equippedCape = null;
		public Weapon previousWeapon = null;
		public Chest previousChest = null;
		public Gauntlet previousGauntlet = null;
		public Ring previousRing = null;
		public Helmet previousHelmet = null;
		public Boot previousBoot = null;
		public Shoulder previousShoulder = null;
		public Cape previousCape = null;

		public void Awake()
		{
			player = FindObjectOfType<Player>();
		}

		public void EquipItem(EquipmentBase item)
		{
			switch (item)
			{
				case Weapon weapon:
					if (equippedWeapon != null)
					{
						UnequipItem(equippedWeapon);
						previousWeapon = equippedWeapon;
					}
					equippedWeapon = weapon;
					break;

				case Chest chest:
					if (equippedChest != null)
					{
						UnequipItem(equippedChest);
						previousChest = equippedChest;
					}
					equippedChest = chest;
					break;

				case Gauntlet gauntlet:
					if (equippedGauntlet != null)
					{
						UnequipItem(equippedGauntlet);
						previousGauntlet = equippedGauntlet;
					}
					equippedGauntlet = gauntlet;
					break;

				case Ring ring:
					if (equippedRing != null)
					{
						UnequipItem(equippedRing);
						previousRing = equippedRing;
					}
					equippedRing = ring;
					break;

				case Helmet helmet:
					if (equippedHelmet != null)
					{
						UnequipItem(equippedHelmet);
						previousHelmet = equippedHelmet;
					}
					equippedHelmet = helmet;
					break;

				case Boot boot:
					if (equippedBoot != null)
					{
						UnequipItem(equippedBoot);
						previousBoot = equippedBoot;
					}
					equippedBoot = boot;
					break;

				case Shoulder shoulder:
					if (equippedShoulder != null)
					{
						UnequipItem(equippedShoulder);
						previousShoulder = equippedShoulder;
					}
					equippedShoulder = shoulder;
					break;

				case Cape cape:
					if (equippedCape != null)
					{
						UnequipItem(equippedCape);
						previousCape = equippedCape;
					}
					equippedCape = cape;
					break;
			}
			Debug.Log("Equipped " + item.displayName);
			// Call the UpdateStats method after equipping an item
			UpdateStats(FindObjectOfType<Player>(), FindObjectOfType<AbilityManager>(), item.type);
		}



		public void UpdateStats(Player player, AbilityManager spellbook, ItemType itemType)
		{
			if (itemType == ItemType.Weapon)
			{
				UpdateEquippedItemStats(ref equippedWeapon, ref previousWeapon, player);
			}
			if (itemType == ItemType.Chest)
			{
				UpdateEquippedItemStats(ref equippedChest, ref previousChest, player);
			}
			if (itemType == ItemType.Gauntlet)
			{
				UpdateEquippedItemStats(ref equippedGauntlet, ref previousGauntlet, player);
			}
			if (itemType == ItemType.Ring)
			{
				UpdateEquippedItemStats(ref equippedRing, ref previousRing, player);
			}
			if (itemType == ItemType.Helmet)
			{
				UpdateEquippedItemStats(ref equippedHelmet, ref previousHelmet, player);
			}
			if (itemType == ItemType.Boot)
			{
				UpdateEquippedItemStats(ref equippedBoot, ref previousBoot, player);
			}
			if (itemType == ItemType.Shoulder)
			{
				UpdateEquippedItemStats(ref equippedShoulder, ref previousShoulder, player);
			}
			if (itemType == ItemType.Cape)
			{
				UpdateEquippedCape(equippedCape, previousCape, player, spellbook);
			}
		}

		private void UpdateEquippedItemStats<T>(ref T equippedItem, ref T previousItem, Player player) where T : EquipmentBase
		{
			if (equippedItem != null)
			{
				AddStatsFromItem(equippedItem, player);
				previousItem = equippedItem;
			}
		}


		private void UpdateEquippedCape(Cape equippedCape, Cape previousCape, Player player, AbilityManager abilityManager)
		{
			if (equippedCape != null)
			{
				if (equippedCape != previousCape)
				{
					if (previousCape != null)
					{
						abilityManager.RemoveAbility(previousCape.boundAbility.displayName);
						ClearAbilityBoxesWithSpell(previousCape.boundAbility);
					}

					if (!abilityManager.GetUnlockedAbilities().Find(s => s.name == equippedCape.boundAbility.displayName))
					{
						abilityManager.UnlockAbility(equippedCape.boundAbility.displayName);
					}
				}
			}
		}

		private void ClearAbilityBoxesWithSpell(SpellData spellToRemove)
		{
			// UIAbilityBox[] abilityBoxes = FindObjectsOfType<UIAbilityBox>();
			// foreach (UIAbilityBox abilityBox in abilityBoxes)
			// {
			// 		if (abilityBox.assignedAbility == spellToRemove)
			// 		{
			// 				abilityBox.ClearAbilityBox(abilityBoxPrefab);
			// 		}
			// }
		}

		public void AddStatsFromItem(EquipmentBase item, Player player)
		{
			Debug.Log("Adding stats from " + item.displayName + " damage range " + item.damageRange.minValue + " - " + item.damageRange.maxValue);
			player.UpdateHealthPoolFromEquipment(item.bonusHp);
			player.healthRegeneration += item.bonusHpRegen;
			player.UpdateAbilityPowerPoolFromEquipment(item.bonusAbilityPower);
			player.abilityRegeneration += item.bonusAbilityPowerRegen;
			player.physDamageResist += item.physDamageResist;
			player.magicDamageResist += item.bonusMagicDamageResist;
			player.critChanceModifier += item.bonusCritChance;
			player.critDamageMultiplier += item.bonusCritDamage;
			player.dodgeChance += item.bonusDodgeChance;
			player.damageRange.maxValue += item.damageRange.maxValue;
			player.damageRange.minValue += item.damageRange.minValue;
			Debug.Log("Health Pool: " + player.healthPool);
		}

		public void RemoveStatsFromItem(EquipmentBase item, Player player)
		{
			player.UpdateHealthPoolFromEquipment(-item.bonusHp);
			player.healthRegeneration -= item.bonusHpRegen;
			player.UpdateAbilityPowerPoolFromEquipment(-item.bonusAbilityPower);
			player.abilityRegeneration -= item.bonusAbilityPowerRegen;
			player.physDamageResist -= item.physDamageResist;
			player.magicDamageResist -= item.bonusMagicDamageResist;
			player.critChanceModifier -= item.bonusCritChance;
			player.critDamageMultiplier -= item.bonusCritDamage;
			player.dodgeChance -= item.bonusDodgeChance;
			player.damageRange.minValue -= item.damageRange.minValue; // Reset DamageRange to default values
			player.damageRange.maxValue -= item.damageRange.maxValue;
		}

		public void UnequipItem(EquipmentBase item)
		{
			RemoveStatsFromItem(item, FindObjectOfType<Player>());
		}
	}
}

