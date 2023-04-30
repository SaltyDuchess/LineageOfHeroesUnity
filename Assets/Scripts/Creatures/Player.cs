using System.Collections.Generic;

public class Player : Creature, ICritStats
{
    public new int XPToNextLevel { get; set; } = 10;
    public new IAbility queuedAbility { get; set; } = null;
    public new float healthRegeneration { get; set; } = 0.5f;
    public new float critChanceModifier { get; set; } = 1;
    public float critDamageModifier { get; set; } = 0.1f;
    public new List<float> damageRange { get; set; } = new List<float> { 10.5f, 13.75f };
    public SpellManager playerSpellbook { get; set; } = null;
    public IClass playerClass { get; set; } = null;
    public PlayerInventory inventory { get; set; } = null;
    public int previousRoom { get; set; } = -1;
}
