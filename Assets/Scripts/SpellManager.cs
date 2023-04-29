using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] private List<Spells> allSpells; // List of all available spells in the game
    [SerializeField] private List<Spells> unlockedSpells; // List of unlocked spells for the player

    public void UnlockSpell(Spells spellToUnlock)
    {
        // Check if the spell is not already unlocked
        if (!unlockedSpells.Contains(spellToUnlock))
        {
            unlockedSpells.Add(spellToUnlock);
            Debug.Log($"Unlocked spell: {spellToUnlock.displayName}");
        }
    }

    public List<Spells> GetAllSpells()
    {
        return allSpells;
    }

    public List<Spells> GetUnlockedSpells()
    {
        return unlockedSpells;
    }

    // Add more spell management functionality here
}
