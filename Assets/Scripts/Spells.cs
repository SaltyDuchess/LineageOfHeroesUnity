using UnityEngine;

public interface Spells : IAbility
{
    public float physDamageModifier { get; set; }
    public float magicDamageModifier { get; set; }
    public float DOT { get; set; }
    public int DOTTurns { get; set; }
    public int stunTurns { get; set; }
		public CalcCritAndDamage calcCritAndDamage { get; set; }

    // Add spell-specific functionality here.
}
