using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using LineageOfHeroes.Spells;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PlayerEquipment : MonoBehaviour
	{
			public List<float> damageRange = new List<float>(2);
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
					damageRange[0] = 0;
					damageRange[1] = 0;

					// Update stats based on equipped items
					UpdateEquippedItemStats(ref equippedWeapon, ref previousWeapon, player);
					UpdateEquippedItemStats(ref equippedChest, ref previousChest, player);
					UpdateEquippedItemStats(ref equippedGauntlet, ref previousGauntlet, player);
					UpdateEquippedItemStats(ref equippedRing, ref previousRing, player);
					UpdateEquippedItemStats(ref equippedHelmet, ref previousHelmet, player);
					UpdateEquippedItemStats(ref equippedBoot, ref previousBoot, player);
					UpdateEquippedItemStats(ref equippedShoulder, ref previousShoulder, player);
					UpdateEquippedCape(ref equippedCape, ref previousCape, player, spellbook);
			}

			private void UpdateEquippedItemStats<T>(ref T equippedItem, ref T previousItem, Player player) where T : IItem
			{
					if (equippedItem != null)
					{
							if (previousItem != null)
							{
									RemoveStatsFromItem(previousItem, player);
							}
							AddStatsFromItem(equippedItem, player);
							previousItem = equippedItem;
					}
			}

			private void UpdateEquippedCape(ref Cape equippedCape, ref Cape previousCape, Player player, SpellManager spellManager)
			{
					if (equippedCape != null)
					{
							if (equippedCape != previousCape)
							{
									if (previousCape != null)
									{
											spellManager.RemoveSpell(previousCape.boundAbility);
											ClearAbilityBoxesWithSpell(previousCape.boundAbility);
									}

									if (!spellManager.GetUnlockedSpells().Contains(equippedCape.boundAbility))
									{
											spellManager.UnlockSpell(equippedCape.boundAbility);
									}

									previousCape = equippedCape;
							}
					}
			}

			private void ClearAbilityBoxesWithSpell(ISpell spellToRemove)
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

			public void AddStatsFromItem(IItem item, Player player)
			{
					bonusHp += item.bonusHp;
					bonusHpRegen += item.bonusHpRegen;
					bonusAbilityPower += item.bonusAbilityPower;
					bonusAbilityPowerRegen += item.bonusAbilityPowerRegen;
					physDamageResist += item.physDamageResist;
					magicDamageResist += item.magicDamageResist;
					bonusCritChance += item.bonusCritChance;
					bonusCritDamage += item.bonusCritDamage;
					damageRange = item.damageRange;
			}

			public void RemoveStatsFromItem(IItem item, Player player)
			{
					bonusHp -= item.bonusHp;
					bonusHpRegen -= item.bonusHpRegen;
					bonusAbilityPower -= item.bonusAbilityPower;
					bonusAbilityPowerRegen -= item.bonusAbilityPowerRegen;
					physDamageResist -= item.physDamageResist;
					magicDamageResist -= item.magicDamageResist;
					bonusCritChance -= item.bonusCritChance;
					bonusCritDamage -= item.bonusCritDamage;
					damageRange = new List<float> { 0, 0 }; // Reset DamageRange to default values
			}

			public float GetDamageValue()
			{
				return RandomGenerator.Range(damageRange[0], damageRange[1]);
			}
	}
}

