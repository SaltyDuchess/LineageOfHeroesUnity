using System.Collections.Generic;
using System.Linq;
using LineageOfHeroes.Spells;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
	public static SpellManager Instance { get; private set; }
	[SerializeField] private SpellLibrary spellLibrary; // Reference to the SpellLibrary
	private List<SpellData> unlockedSpells; // List of unlocked spells for the player
	private List<SpellBase> activeSpells; // List of active spells for the player

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			unlockedSpells = new List<SpellData>();
			activeSpells = new List<SpellBase>();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void UnlockSpell(string spellName)
	{
		SpellData spellToUnlock = spellLibrary.GetSpellByName(spellName);
		if (spellToUnlock != null && !unlockedSpells.Contains(spellToUnlock))
		{
			unlockedSpells.Add(spellToUnlock);
			Debug.Log($"Unlocked spell: {spellToUnlock.spellName}");
		}
	}

	public void RemoveSpell(string spellName)
	{
		SpellData spellToRemove = unlockedSpells.FirstOrDefault(spell => spell.spellName == spellName);
		if (spellToRemove != null)
		{
			unlockedSpells.Remove(spellToRemove);
			Debug.Log($"Removed spell: {spellToRemove.spellName}");
		}
	}

	public List<SpellData> GetUnlockedSpells()
	{
		return unlockedSpells;
	}

	public void AddActiveSpell(SpellBase spell)
	{
		activeSpells.Add(spell);
	}

	public void RemoveActiveSpell(SpellBase spell)
	{
		activeSpells.Remove(spell);
	}

	public List<SpellBase> GetActiveSpells()
	{
		return activeSpells;
	}

	public void AdvanceCooldownsOnActiveSpells()
	{
		if (activeSpells == null)
		{
			return;
		}
		foreach (SpellBase spell in activeSpells)
		{
			if (spell.currentCooldown > 0)
			{
				spell.currentCooldown--;
			}
		}
	}
}
