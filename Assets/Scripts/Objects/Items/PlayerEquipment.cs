using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PlayerEquipment : MonoBehaviour
	{
		public StatRange damageRange;
		public float bonusCritChance = 0;
		public float bonusCritDamage = 0;
		public float bonusHp = 0;
		public float bonusAbilityPower = 0;
		public float bonusHpRegen = 0;
		public float bonusAbilityPowerRegen = 0;
		public float physDamageResist = 0;
		public float magicDamageResist = 0;
		public float bonusDodgeChance = 0;
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

		public void EquipItem(EquipmentBase item)
		{
			switch (item)
			{
				case Weapon weapon:
					if (equippedWeapon != null)
					{
						UnequipItem(equippedWeapon);
						previousWeapon = null;
					}
					equippedWeapon = weapon;
					break;

				case Chest chest:
					if (equippedChest != null)
					{
						UnequipItem(equippedChest);
						previousChest = null;
					}
					equippedChest = chest;
					break;

				case Gauntlet gauntlet:
					if (equippedGauntlet != null)
					{
						UnequipItem(equippedGauntlet);
						previousGauntlet = null;
					}
					equippedGauntlet = gauntlet;
					break;

				case Ring ring:
					if (equippedRing != null)
					{
						UnequipItem(equippedRing);
						previousRing = null;
					}
					equippedRing = ring;
					break;

				case Helmet helmet:
					if (equippedHelmet != null)
					{
						UnequipItem(equippedHelmet);
						previousHelmet = null;
					}
					equippedHelmet = helmet;
					break;

				case Boot boot:
					if (equippedBoot != null)
					{
						UnequipItem(equippedBoot);
						previousBoot = null;
					}
					equippedBoot = boot;
					break;

				case Shoulder shoulder:
					if (equippedShoulder != null)
					{
						UnequipItem(equippedShoulder);
						previousShoulder = null;
					}
					equippedShoulder = shoulder;
					break;

				case Cape cape:
					if (equippedCape != null)
					{
						UnequipItem(equippedCape);
						previousCape = null;
					}
					equippedCape = cape;
					break;
			}

			// Call the UpdateStats method after equipping an item
			UpdateStats(FindObjectOfType<Player>(), FindObjectOfType<SpellManager>());
		}



		public void UpdateStats(Player player, SpellManager spellbook)
		{
			// Reset stats
			bonusHp = 0;
			bonusHpRegen = 0;
			bonusAbilityPower = 0;
			bonusAbilityPowerRegen = 0;
			physDamageResist = 0;
			magicDamageResist = 0;
			bonusCritChance = 0;
			bonusCritDamage = 0;
			damageRange.minValue = 0;
			damageRange.maxValue = 0;

			// Update stats based on equipped items
			UpdateEquippedItemStats(ref equippedWeapon, ref previousWeapon, player);
			UpdateEquippedItemStats(ref equippedChest, ref previousChest, player);
			UpdateEquippedItemStats(ref equippedGauntlet, ref previousGauntlet, player);
			UpdateEquippedItemStats(ref equippedRing, ref previousRing, player);
			UpdateEquippedItemStats(ref equippedHelmet, ref previousHelmet, player);
			UpdateEquippedItemStats(ref equippedBoot, ref previousBoot, player);
			UpdateEquippedItemStats(ref equippedShoulder, ref previousShoulder, player);
			UpdateEquippedCape(equippedCape, previousCape, player, spellbook);
		}

		private void UpdateEquippedItemStats<T>(ref T equippedItem, ref T previousItem, Player player) where T : EquipmentBase
		{
			if (equippedItem != null)
			{
				AddStatsFromItem(equippedItem, player);
				previousItem = equippedItem;
			}
		}


		private void UpdateEquippedCape(Cape equippedCape, Cape previousCape, Player player, SpellManager spellManager)
		{
			if (equippedCape != null)
			{
				if (equippedCape != previousCape)
				{
					if (previousCape != null)
					{
						spellManager.RemoveSpell(previousCape.boundAbility.spellName);
						ClearAbilityBoxesWithSpell(previousCape.boundAbility);
					}

					if (!spellManager.GetUnlockedSpells().Find(s => s.name == equippedCape.boundAbility.spellName))
					{
						spellManager.UnlockSpell(equippedCape.boundAbility.spellName);
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
			bonusHp += item.bonusHp;
			bonusHpRegen += item.bonusHpRegen;
			bonusAbilityPower += item.bonusAbilityPower;
			bonusAbilityPowerRegen += item.bonusAbilityPowerRegen;
			physDamageResist += item.physDamageResist;
			magicDamageResist += item.bonusMagicDamageResist;
			bonusCritChance += item.bonusCritChance;
			bonusCritDamage += item.bonusCritDamage;
			bonusDodgeChance += item.bonusDodgeChance;
			damageRange.maxValue += item.damageRange.maxValue;
			damageRange.minValue += item.damageRange.minValue;
		}

		public void RemoveStatsFromItem(EquipmentBase item, Player player)
		{
			bonusHp -= item.bonusHp;
			bonusHpRegen -= item.bonusHpRegen;
			bonusAbilityPower -= item.bonusAbilityPower;
			bonusAbilityPowerRegen -= item.bonusAbilityPowerRegen;
			physDamageResist -= item.physDamageResist;
			magicDamageResist -= item.bonusMagicDamageResist;
			bonusCritChance -= item.bonusCritChance;
			bonusCritDamage -= item.bonusCritDamage;
			bonusDodgeChance -= item.bonusDodgeChance;
			damageRange.minValue -= item.damageRange.minValue; // Reset DamageRange to default values
			damageRange.maxValue -= item.damageRange.maxValue;
		}

		public void UnequipItem(EquipmentBase item)
		{
			RemoveStatsFromItem(item, FindObjectOfType<Player>());
		}


		public float GetDamageValue()
		{
			return RandomGenerator.Range(damageRange.minValue, damageRange.maxValue);
		}
	}
}

