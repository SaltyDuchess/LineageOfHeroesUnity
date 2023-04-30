using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;


public class SpellManager : MonoBehaviour
{
    [SerializeField] private List<ISpell> allSpells; // List of all available spells in the game
    [SerializeField] private List<ISpell> unlockedSpells; // List of unlocked spells for the player

    public void UnlockSpell(ISpell spellToUnlock)
    {
        // Check if the spell is not already unlocked
        if (!unlockedSpells.Contains(spellToUnlock))
        {
            unlockedSpells.Add(spellToUnlock);
            Debug.Log($"Unlocked spell: {spellToUnlock.displayName}");
        }
    }

    public void RemoveSpell(ISpell spellToRemove)
    {
        if (unlockedSpells.Contains(spellToRemove))
        {
            unlockedSpells.Remove(spellToRemove);
            Debug.Log($"Removed spell: {spellToRemove.displayName}");
        }
    }

    public List<ISpell> GetAllSpells()
    {
        return allSpells;
    }

    public List<ISpell> GetUnlockedSpells()
    {
        return unlockedSpells;
    }

    // Add more spell management functionality here
}
