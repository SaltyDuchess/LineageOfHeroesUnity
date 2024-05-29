using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

[CreateAssetMenu(fileName = "MagiSpellData", menuName = "Spells/MagiSpellData", order = 1)]
public class MagiSpellData : SpellData
{
    public MagiSpellType magiSpellType;

    // Berzerker-specific properties and methods can be added here
}