using System.Collections.Generic;
using LineageOfHeroes.SpellFactory;
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
	private SpellFactory spellFactory;
	private TextMeshProUGUI playerStatsText;
	private List<SpellBase> createdSpellInstances = new List<SpellBase>();


	void Awake()
	{
		player = FindObjectOfType<Player>();
		abilityPointIndicator = Instantiate(abilityPointIndicatorPrefab, FindObjectOfType<Canvas>().transform);
		abilityPointIndicator.SetActive(false);
		spellFactory = FindObjectOfType<SpellFactory>();
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
		spellFactory = FindObjectOfType<SpellFactory>();
		// Instantiate the overlay
		overlay = Instantiate(overlayPrefab, FindObjectOfType<Canvas>().transform);

		// Assign the CloseLevelUpUI method to the close button's onClick event
		Button closeButton = overlay.transform.Find("CloseButton").GetComponent<Button>();
		closeButton.onClick.AddListener(CloseLevelUpUI);

		// Find and assign the PlayerStatsText object
		playerStatsText = overlay.transform.Find("PlayerStatsText").GetComponent<TextMeshProUGUI>();

		// Update the player stats text
		UpdatePlayerStatsText();

		// Iterate through the player's class spells and create a UI object for each one
		foreach (SpellData spell in player.playerClass.classSpells)
		{
			SpellBase spellInstance = spellFactory.CreateSpell(spell);
			createdSpellInstances.Add(spellInstance);
			GameObject spellUI = Instantiate(spellLevelUpPrefab);
			spellUI.transform.SetParent(overlay.transform.Find("SpellUILevelupLayout").transform, false);

			// Set the properties of the spell UI object (e.g., image, text)
			spellUI.GetComponent<Image>().sprite = spellInstance.uiElement;

			// Get the reference to TooltipTrigger component
			tooltipTrigger = spellUI.GetComponent<TooltipTrigger>();

			// Set the tooltipText using SetTooltipText method
			tooltipTrigger.SetTooltipText(spellInstance.descriptionLong);

			// Update the spellUI color
			UpdateSpellUI(spellUI, spell);

			// Add the click event to the spellUI
			Button spellUIButton = spellUI.GetComponentInChildren<Button>(true);
			spellUIButton.onClick.AddListener(() => UnlockSpellForPlayer(spell));
		}
	}

	public void UnlockSpellForPlayer(SpellData spell)
	{
		// Check if the player has enough ability points and if the spell is available
		if (player.abilityPoints > 0 && player.currentLevel >= spell.levelRequirement)
		{
			SpellManager spellManager = FindObjectOfType<SpellManager>();
			// Unlock the spell and deduct an ability point
			spellManager.UnlockSpell(spell.spellName);
			player.abilityPoints--;

			// Update the player stats text
			UpdatePlayerStatsText();
			// Update the UI to show the spell as unlocked
			// ...

			// Update the spellUI color for all spellUI objects
			foreach (Transform spellUITransform in overlay.transform.Find("SpellUILevelupLayout").transform)
			{
				GameObject spellUI = spellUITransform.gameObject;
				UpdateSpellUI(spellUI, spell);
			}
		}
	}

	private void UpdateSpellUI(GameObject spellUI, SpellData spell)
	{
		// Check if the player's level is lower than the required level for the spell or if the player doesn't have ability points
		bool spellUnavailable = player.currentLevel < spell.levelRequirement || player.abilityPoints <= 0;

		// Change the spellUI color to be grayed out if the spell is unavailable
		Color color = spellUnavailable ? new Color(0.5f, 0.5f, 0.5f, 0.5f) : Color.white;
		spellUI.GetComponent<Image>().color = color;

		// Apply the same color change to the child image
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
		// Destroy the overlay GameObject along with all its child elements
		Destroy(overlay);

		// Destroy the created SpellBase instances and clear the list
		foreach (SpellBase spellInstance in createdSpellInstances)
		{
			Destroy(spellInstance.gameObject);
		}
		createdSpellInstances.Clear();
	}
}
