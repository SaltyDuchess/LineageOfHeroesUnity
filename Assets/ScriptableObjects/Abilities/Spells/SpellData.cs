using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

public class SpellData : AbilityData
{
    public SpellType spellType;
    public float physDamageModifier;
    public float magicDamageModifier;
    public float DOT;
    public int DOTTurns;
    public int stunTurns;
}
