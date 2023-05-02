using System.Collections.Generic;
using System.Linq;
using LineageOfHeroes.Spells;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
	public static SpellManager Instance { get; private set; }
	[SerializeField] private SpellLibrary spellLibrary; // Reference to the SpellLibrary
	private List<SpellBase> unlockedSpells; // List of unlocked spells for the player

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			unlockedSpells = new List<SpellBase>();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void UnlockSpell(string spellName)
	{
		SpellBase spellToUnlock = spellLibrary.GetSpellByName(spellName);
		if (spellToUnlock != null && !unlockedSpells.Contains(spellToUnlock))
		{
			unlockedSpells.Add(spellToUnlock);
			Debug.Log($"Unlocked spell: {spellToUnlock.displayName}");
		}
	}

	public void RemoveSpell(string spellName)
	{
		SpellBase spellToRemove = unlockedSpells.FirstOrDefault(spell => spell.displayName == spellName);
		if (spellToRemove != null)
		{
			unlockedSpells.Remove(spellToRemove);
			Debug.Log($"Removed spell: {spellToRemove.displayName}");
		}
	}

	public List<SpellBase> GetUnlockedSpells()
	{
		return unlockedSpells;
	}

	// Add more spell management functionality here
}
