using System.Collections.Generic;
using System.Linq;
using LineageOfHeroes.Spells;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
	public static AbilityManager Instance { get; private set; }
	[SerializeField] private SpellLibrary spellLibrary;
	[SerializeField] private ConsumableLibrary consumableLibrary;
	private List<AbilityData> unlockedAbilities;
	private List<AbilityBase> activeAbilities;
	private List<SpellBase> activeSustainedSpells; // List of active sustained spells
	private List<PermanentUpgradeData> permanentUpgrades;
	private List<PermanentUpgradeBase> activePermanentUpgrades;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			unlockedAbilities = new List<AbilityData>();
			activeAbilities = new List<AbilityBase>();
			activeSustainedSpells = new List<SpellBase>();
			permanentUpgrades = new List<PermanentUpgradeData>();
			activePermanentUpgrades = new List<PermanentUpgradeBase>();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public bool UnlockAbility(string abilityName)
	{
		AbilityData abilityToUnlock = GetAbilityByName(abilityName);
		if (abilityToUnlock != null && !unlockedAbilities.Contains(abilityToUnlock) && !permanentUpgrades.Contains(abilityToUnlock))
		{
			if (abilityToUnlock is PermanentUpgradeData permanentUpgrade)
			{
				permanentUpgrades.Add(permanentUpgrade);
				ApplyPermanentUpgrade(permanentUpgrade);
			}
			else 
			{
				unlockedAbilities.Add(abilityToUnlock);
			}
			Debug.Log($"Unlocked ability: {abilityToUnlock.displayName}");
			return true;
		}
		return false;
	}

	public void RemoveAbility(string abilityName)
	{
		AbilityData abilityToRemove = unlockedAbilities.FirstOrDefault(ability => ability.displayName == abilityName);
		if (abilityToRemove != null)
		{
			unlockedAbilities.Remove(abilityToRemove);
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

	public void AddActivePermanentAbility(PermanentUpgradeBase upgrade)
	{
		if (!activePermanentUpgrades.Contains(upgrade))
		{
			activePermanentUpgrades.Add(upgrade);
		}
	}

	public void RemoveActivePermanentAbility(PermanentUpgradeBase upgrade)
	{
		if (activePermanentUpgrades.Contains(upgrade))
		{
			activePermanentUpgrades.Remove(upgrade);
		}
	}

	public void AddSustainedSpell(SpellBase spell)
	{
		if (!activeSustainedSpells.Contains(spell))
		{
			activeSustainedSpells.Add(spell);
		}
	}

	public void RemoveSustainedSpell(SpellBase spell)
	{
		if (activeSustainedSpells.Contains(spell))
		{
			spell.currentCooldown = spell.spellData.cooldown;
			activeSustainedSpells.Remove(spell);
		}
	}

	public List<SpellBase> GetActiveSustainedSpells()
	{
		return activeSustainedSpells;
	}

	public void ApplySustainedSpells(Player player)
	{
		foreach (var spell in activeSustainedSpells)
		{
			spell.ExecuteAbility(player);
		}
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

	public void ExecuteAllTurnRecurringPermanentUpgrades()
	{
		foreach (PermanentUpgradeBase upgrade in activePermanentUpgrades)
		{
			if (upgrade.permanentUpgradeData.turnRecurring)
			{
				upgrade.ExecuteAbility();
			}
		}
	}

	private AbilityData GetAbilityByName(string abilityName)
	{
		AbilityData spellData = spellLibrary?.GetSpellByName(abilityName);
		if (spellData != null)
		{
			return spellData;
		}

		ConsumableData consumableData = consumableLibrary?.GetConsumableByName(abilityName);
		return consumableData;
	}

	private void ApplyPermanentUpgrade(PermanentUpgradeData upgrade)
	{
		if (upgrade.healthIncreasePercentage > 0)
		{
			GlobalEffectsManager.Instance.PlayerPercentageHPBoost = upgrade.healthIncreasePercentage / 100f;
		}
		if (upgrade.abilityPowerIncreasePercentage > 0)
		{
			GlobalEffectsManager.Instance.PlayerPercentageAbilityPowerBoost = upgrade.abilityPowerIncreasePercentage / 100f;
		}
		if (upgrade.bleedsCanCrit)
		{
			GlobalEffectsManager.Instance.bleedsCanCrit = true;
			GlobalEffectsManager.Instance.bleedCritChance = upgrade.bleedCritChance;
			GlobalEffectsManager.Instance.bleedCritModifier = upgrade.bleedCritModifier;
		}
	}
}
