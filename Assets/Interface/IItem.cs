using System.Collections.Generic;
using UnityEngine;

public interface IItem : IAbility, ICritStats
{
    public int quantity { get; set; }
    public string type { get; set; }
    public Sprite UiElement { get; set; }
    public Spells boundAbility { get; set; }
		public float bonusHp { get; set; }
    public float bonusHpRegen { get; set; }
    public float bonusAbilityPower { get; set; }
    public float bonusAbilityPowerRegen { get; set; }
    public float physDamageResist { get; set; }
    public float magicDamageResist { get; set; }
		public float bonusDodgeChance { get; set; }
		public float bonusCritChance { get; set; }
    public float bonusCritDamage { get; set; }
		public new float critChanceModifier { get; set; }
    public new float critDamageMultiplier { get; set; }
    public List<float> damageRange { get; set; }
		public Rarity itemRarity { get; set; }
}
