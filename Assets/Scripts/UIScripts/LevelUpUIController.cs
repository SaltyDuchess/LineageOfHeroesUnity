using System.Collections.Generic;
using LineageOfHeroes.Spells;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIController : MonoBehaviour
{
	public GameObject abilityPointIndicatorPrefab;
	public GameObject overlayPrefab;
	public GameObject spellLevelUpPrefab;

	private Player player;
	private GameObject abilityPointIndicator;
	private GameObject overlay;
	private TooltipTrigger tooltipTrigger;
	private AbilityFactory abilityFactory;
	private TextMeshProUGUI playerStatsText;
	private List<SpellBase> createdSpellInstances = new List<SpellBase>();

	void Awake()
	{
		player = FindObjectOfType<Player>();
		abilityPointIndicator = Instantiate(abilityPointIndicatorPrefab, FindObjectOfType<Canvas>().transform);
		abilityPointIndicator.SetActive(false);
		abilityFactory = FindObjectOfType<AbilityFactory>();
	}

	void Update()
	{
		if (player.abilityPoints > 0)
		{
			abilityPointIndicator.SetActive(true);
		}
		else
		{
			abilityPointIndicator.SetActive(false);
		}
	}

	public void OnAbilityPointIndicatorClicked()
	{
		player = FindObjectOfType<Player>();
		abilityFactory = FindObjectOfType<AbilityFactory>();
		overlay = Instantiate(overlayPrefab, FindObjectOfType<Canvas>().transform);

		Button closeButton = overlay.transform.Find("CloseButton").GetComponent<Button>();
		closeButton.onClick.AddListener(CloseLevelUpUI);

		playerStatsText = overlay.transform.Find("PlayerStatsText").GetComponent<TextMeshProUGUI>();
		UpdatePlayerStatsText();

		foreach (SpellData spell in player.playerClass.classSpells)
		{
			CreateSpellUI(spell);
		}

		foreach (PermanentUpgradeData upgrade in player.playerClass.classPermanentUpgrades)
		{
			CreateUpgradeUI(upgrade);
		}
	}

	private void CreateSpellUI(SpellData spell)
	{
		SpellBase spellInstance = (SpellBase)abilityFactory.CreateAbility(spell);
		createdSpellInstances.Add(spellInstance);
		GameObject spellUI = Instantiate(spellLevelUpPrefab);
		spellUI.transform.SetParent(overlay.transform.Find("SpellUILevelupLayout").transform, false);

		spellUI.GetComponent<Image>().sprite = spellInstance.uiElement;
		tooltipTrigger = spellUI.GetComponent<TooltipTrigger>();
		tooltipTrigger.SetTooltipText(spellInstance.descriptionLong);
		UpdateSpellUI(spellUI, spell);

		Button spellUIButton = spellUI.GetComponentInChildren<Button>(true);
		spellUIButton.onClick.AddListener(() => UnlockSpellForPlayer(spell));
	}

	private void CreateUpgradeUI(PermanentUpgradeData upgrade)
	{
		GameObject upgradeUI = Instantiate(spellLevelUpPrefab);
		upgradeUI.transform.SetParent(overlay.transform.Find("SpellUILevelupLayout").transform, false);

		upgradeUI.GetComponent<Image>().sprite = upgrade.uiElement;
		tooltipTrigger = upgradeUI.GetComponent<TooltipTrigger>();
		tooltipTrigger.SetTooltipText(upgrade.descriptionLong);
		UpdateSpellUI(upgradeUI, upgrade);

		Button upgradeUIButton = upgradeUI.GetComponentInChildren<Button>(true);
		upgradeUIButton.onClick.AddListener(() => UnlockUpgradeForPlayer(upgrade));
	}

	public void UnlockSpellForPlayer(SpellData spell)
	{
		if (player.abilityPoints > 0 && player.currentLevel >= spell.levelRequirement)
		{
			AbilityManager spellManager = FindObjectOfType<AbilityManager>();
			bool abilityUnlocked = spellManager.UnlockAbility(spell.displayName);

			if (abilityUnlocked)
			{
				player.abilityPoints--;
			}

			UpdatePlayerStatsText();

			foreach (Transform spellUITransform in overlay.transform.Find("SpellUILevelupLayout").transform)
			{
				GameObject spellUI = spellUITransform.gameObject;
				UpdateSpellUI(spellUI, spell);
			}
		}
	}

	public void UnlockUpgradeForPlayer(PermanentUpgradeData upgrade)
	{
		if (player.abilityPoints > 0 && player.currentLevel >= upgrade.levelRequirement)
		{
			AbilityManager abilityManager = FindObjectOfType<AbilityManager>();
			bool abilityUnlocked = abilityManager.UnlockAbility(upgrade.displayName);
			if (abilityUnlocked)
			{
				player.abilityPoints--;
			}

			UpdatePlayerStatsText();
		}
	}

	private void UpdateSpellUI(GameObject spellUI, AbilityData spell)
	{
		bool spellUnavailable = player.currentLevel < spell.levelRequirement || player.abilityPoints <= 0;
		Color color = spellUnavailable ? new Color(0.5f, 0.5f, 0.5f, 0.5f) : Color.white;
		spellUI.GetComponent<Image>().color = color;

		Image[] childImages = spellUI.GetComponentsInChildren<Image>(true);
		if (childImages.Length > 1)
		{
			childImages[1].color = color;
		}
	}

	private void UpdatePlayerStatsText()
	{
		playerStatsText.text = $"Level: {player.currentLevel}\n" +
													 $"Ability Points: {player.abilityPoints}\n" +
													 $"XP: {player.currentXP}\n" +
													 $"XP to Next Level: {player.XPToNextLevel}";
	}

	public void CloseLevelUpUI()
	{
		foreach (SpellBase spellInstance in createdSpellInstances)
		{
			if (spellInstance != null)
			{
				Destroy(spellInstance.gameObject);
			}
		}

		createdSpellInstances.Clear();
		Destroy(overlay);
	}
}
