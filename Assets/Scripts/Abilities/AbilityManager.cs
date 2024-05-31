using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
	public static AbilityManager Instance { get; private set; }
	[SerializeField] private SpellLibrary spellLibrary; // Reference to the SpellLibrary
	[SerializeField] private ConsumableLibrary consumableLibrary; // Reference to the ConsumableLibrary
	private List<AbilityData> unlockedAbilities; // List of unlocked abilities for the player
	private List<AbilityBase> activeAbilities; // List of active abilities for the player

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			unlockedAbilities = new List<AbilityData>();
			activeAbilities = new List<AbilityBase>();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void UnlockAbility(string abilityName)
	{
		AbilityData abilityToUnlock = GetAbilityByName(abilityName);
		if (abilityToUnlock != null && !unlockedAbilities.Contains(abilityToUnlock))
		{
			unlockedAbilities.Add(abilityToUnlock);
			Debug.Log($"Unlocked ability: {abilityToUnlock.displayName}");
		}
	}

	public void RemoveAbility(string abilityName)
	{
		AbilityData abilityToRemove = unlockedAbilities.FirstOrDefault(ability => ability.displayName == abilityName);
		if (abilityToRemove != null)
		{
			unlockedAbilities.Remove(abilityToRemove);
			Debug.Log($"Removed ability: {abilityToRemove.displayName}");
		}
	}

	public List<AbilityData> GetUnlockedAbilities()
	{
		return unlockedAbilities;
	}

	public void AddActiveAbility(AbilityBase ability)
	{
		activeAbilities.Add(ability);
	}

	public void RemoveActiveAbility(AbilityBase ability)
	{
		activeAbilities.Remove(ability);
	}

	public List<AbilityBase> GetActiveAbilities()
	{
		return activeAbilities;
	}

	public void AdvanceCooldownsOnActiveAbilities()
	{
		if (activeAbilities == null)
		{
			return;
		}
		foreach (AbilityBase ability in activeAbilities)
		{
			if (ability.currentCooldown > 0)
			{
				ability.currentCooldown--;
			}
		}
	}

	private AbilityData GetAbilityByName(string abilityName)
	{
		SpellData spellData = spellLibrary?.GetSpellByName(abilityName);
		if (spellData != null)
		{
			return spellData;
		}

		ConsumableData consumableData = consumableLibrary?.GetConsumableByName(abilityName);
		return consumableData;
	}
}