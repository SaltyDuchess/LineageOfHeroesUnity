using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellLibrary : MonoBehaviour
{
    [SerializeField] private List<SpellData> allSpells; // List of all available spells in the game

    public SpellData GetSpellByName(string spellName)
    {
      return allSpells.FirstOrDefault(spell => spell.spellName == spellName);
    }

    // Add more methods to search for spells if needed
}
