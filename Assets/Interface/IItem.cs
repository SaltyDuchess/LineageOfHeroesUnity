using System.Collections.Generic;
using LineageOfHeroes.Spells;
using LineageOfHeroes.ItemTypes;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public interface IItem : IAbility
	{
			public int quantity { get; set; }
			public Sprite UiElement { get; set; }
			public SpellData boundAbility { get; set; }
			public ItemType type { get; set; }
			public float bonusHp { get; set; }
			public float bonusHpRegen { get; set; }
			public float bonusAbilityPower { get; set; }
			public float bonusAbilityPowerRegen { get; set; }
			public float physDamageResist { get; set; }
			public float bonusMagicDamageResist { get; set; }
			public float bonusDodgeChance { get; set; }
			public float bonusCritChance { get; set; }
			public float bonusCritDamage { get; set; }
			public StatRange damageRange { get; set; }
			public Rarity itemRarity { get; set; }
			[System.Serializable]
			public struct ItemDrop
			{
				public EquipmentBase item;
				public float dropWeight;
			}
	}
}
