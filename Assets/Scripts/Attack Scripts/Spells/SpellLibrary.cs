using System.Collections.Generic;
using System.Linq;
using LineageOfHeroes.Spells;
using UnityEngine;

public class SpellLibrary : MonoBehaviour
{
    [SerializeField] private List<SpellBase> allSpells; // List of all available spells in the game

    public SpellBase GetSpellByName(string spellName)
    {
        return allSpells.FirstOrDefault(spell => spell.displayName == spellName);
    }

    // Add more methods to search for spells if needed
}
