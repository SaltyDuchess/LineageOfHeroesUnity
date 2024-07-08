using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellLibrary : MonoBehaviour
{
    [SerializeField] private List<AbilityData> allSpells; // List of all available spells in the game

    public AbilityData GetSpellByName(string spellName)
    {
      return allSpells.FirstOrDefault(spell => spell.displayName == spellName);
    }

    // Add more methods to search for spells if needed
}
