using System.Collections.Generic;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.Spells;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class EquipmentBase : MonoBehaviour, IItem
	{
			[SerializeField] protected EquipmentData equipmentData;
			public int quantity { get; set; } = 1;
			public ItemType type { get; set; }
			public Sprite UiElement { get; set; }
			public ISpell boundAbility { get; set; }
			public float bonusHp { get; set; }
			public float bonusHpRegen { get; set; }
			public float bonusAbilityPower { get; set; }
			public float bonusAbilityPowerRegen { get; set; }
			public float physDamageResist { get; set; }
			public float magicDamageResist { get; set; }
			public float bonusDodgeChance { get; set; }
			public float bonusCritChance { get; set; }
			public float bonusCritDamage { get; set; }
			public float critChanceModifier { get; set; }
			public float critDamageMultiplier { get; set; }
			public List<float> damageRange { get; set; }
			public string displayName { get; set; }
			public Sprite uiElement { get; set; }
			public int cooldown { get; set; }
			public int currentCooldown { get; set; }
			public int levelRequirement { get; set; }
			public string descriptionLong { get; set; }
			public bool instantCast { get; set; }
			public float abilityPowerCost { get; set; }
			public bool isCastable { get; set; }
			public ICreature targetedEnemy { get; set; }
			public Rarity itemRarity { get; set; }

			protected virtual void Awake()
			{
				displayName = equipmentData.displayName;
				itemRarity = equipmentData.itemRarity;
				descriptionLong = equipmentData.descriptionLong;
				uiElement = equipmentData.uiElement;
			}
	}
}