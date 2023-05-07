using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

[CreateAssetMenu(fileName = "SummonerSpellData", menuName = "Spells/SummonerSpellData", order = 1)]
public class SummonerSpellData : SpellData
{
    public SummonerSpellType summonerSpellType;

    // Berzerker-specific properties and methods can be added here
}