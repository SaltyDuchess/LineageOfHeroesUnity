using LineageOfHeroes.ItemTypes;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class EquipmentBase : MonoBehaviour, IItem
	{
		public EquipmentData equipmentData;
		public int quantity { get; set; } = 1;
		public ItemType type { get; set; }
		public Sprite UiElement { get; set; }
		public SpellData boundAbility { get; set; }
		public float bonusHp { get; set; }
		public float bonusHpRegen { get; set; }
		public float bonusAbilityPower { get; set; }
		public float bonusAbilityPowerRegen { get; set; }
		public float physDamageResist { get; set; }
		public float eqPhysDamageResist { get; set; }
		public float bonusMagicDamageResist { get; set; }
		public float bonusDodgeChance { get; set; }
		public float bonusCritChance { get; set; }
		public float bonusCritDamage { get; set; }
		public float bonusSpeedPool { get; set; }
		public StatRange critChanceModifier { get; set; }
		public StatRange critDamageMultiplier { get; set; }
		public StatRange damageRange { get; set; }
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
		public float autoAttackRange { get; set; }
		public float damageOverTime { get; set; }
		public int damageOverTimeTurns { get; set; }
		private TooltipTrigger tooltipTrigger;



		protected virtual void Awake()
		{
			displayName = equipmentData.displayName;
			itemRarity = equipmentData.itemRarity;
			uiElement = equipmentData.uiElement;
			bonusHp = equipmentData.stats.bonusHp.GetRandomValue();
			bonusHpRegen = equipmentData.stats.bonusHpRegen.GetRandomValue();
			bonusAbilityPower = equipmentData.stats.bonusAbilityPower.GetRandomValue();
			bonusAbilityPowerRegen = equipmentData.stats.bonusAbilityPowerRegen.GetRandomValue();
			bonusDodgeChance = equipmentData.stats.bonusDodgeChance.GetRandomValue();
			bonusCritChance = equipmentData.stats.bonusCritChance.GetRandomValue();
			bonusCritDamage = equipmentData.stats.bonusCritDamage.GetRandomValue();
			bonusSpeedPool = equipmentData.stats.bonusSpeedPool.GetRandomValue();
			physDamageResist = equipmentData.stats.bonusPhysDamageResist.GetRandomValue();
			bonusMagicDamageResist = equipmentData.stats.bonusMagicDamageResist.GetRandomValue();
			physDamageResist = equipmentData.stats.bonusPhysDamageResist.GetRandomValue();
			autoAttackRange = equipmentData.stats.autoAttackRange;
			damageOverTime = equipmentData.stats.damageOverTime;
			damageOverTimeTurns = equipmentData.stats.damageOverTimeTurns;
			damageRange = equipmentData.stats.damageRange;
			critDamageMultiplier = equipmentData.stats.bonusCritDamage;
			critChanceModifier = equipmentData.stats.bonusCritChance;

			// Get the reference to TooltipTrigger component
			tooltipTrigger = GetComponent<TooltipTrigger>();

			// Set display name and type on description long
			descriptionLong = $"{displayName}\nType - {type}\n";

			AddStatsToDescriptionLong();

			// Set the tooltipText using SetTooltipText method
			tooltipTrigger.SetTooltipText(descriptionLong);
		}


		public void AddStatsToDescriptionLong()
		{
			if (bonusHp != 0)
				descriptionLong += $"Bonus HP: {bonusHp}\n";

			if (bonusHpRegen != 0)
				descriptionLong += $"Bonus HP Regen: {bonusHpRegen}\n";

			if (bonusAbilityPower != 0)
				descriptionLong += $"Bonus Ability Power: {bonusAbilityPower}\n";

			if (bonusAbilityPowerRegen != 0)
				descriptionLong += $"Bonus Ability Power Regen: {bonusAbilityPowerRegen}\n";

			if (bonusDodgeChance != 0)
				descriptionLong += $"Bonus Dodge Chance: {bonusDodgeChance}\n";

			if (bonusCritChance != 0)
				descriptionLong += $"Bonus Crit Chance: {bonusCritChance}\n";

			if (bonusCritDamage != 0)
				descriptionLong += $"Bonus Crit Damage: {bonusCritDamage}\n";

			if (bonusSpeedPool != 0)
				descriptionLong += $"Bonus Speed Pool: {bonusSpeedPool}\n";

			if (bonusMagicDamageResist != 0)
				descriptionLong += $"Bonus Magic Damage Resist: {bonusMagicDamageResist}\n";

			if (physDamageResist != 0)
				descriptionLong += $"Bonus Physical Damage Resist: {physDamageResist}\n";

			if (autoAttackRange != 0)
				descriptionLong += $"Auto Attack Range: {autoAttackRange}\n";

			if (damageOverTime != 0)
				descriptionLong += $"Damage Over Time: {damageOverTime} for {damageOverTimeTurns} turns\n";

			if (damageRange.minValue != 0 || damageRange.maxValue != 0)
				descriptionLong += $"Damage Range: {damageRange.minValue}-{damageRange.maxValue}\n";
		}
	}
}