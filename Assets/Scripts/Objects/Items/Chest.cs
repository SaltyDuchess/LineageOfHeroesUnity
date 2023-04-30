using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.ChestType;

namespace LineageOfHeroes.Items
{
	public abstract class Chest : IItem
	{
			public int quantity { get; set; } = 1;
			public ItemType type { get; set; } = ItemType.Chest;
			public ChestType chestType { get; set; }
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
			public Creature targetedEnemy { get; set; }
			public Rarity itemRarity { get; set; }
	}
}
