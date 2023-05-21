using System.Collections.Generic;
using LineageOfHeroes.SpellFactory;
using LineageOfHeroes.Spells;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityBoxController : MonoBehaviour
{
	public GameObject spellUIPrefab;
	public GameObject spellSelectionPanelPrefab;
	public SpellFactory masterSpellFactory;
	public Color activeAbilityBoxColor = Color.yellow;
	public Color notEnoughPowerColor = new Color(1, 0, 0, 0.3f);

	private SpellBase boundSpellInstance;
	private SpellData boundSpellData;
	private GameObject spellSelectionPanel;
	private Image abilityBoxImage;
	private Sprite originalSprite;
	private Color originalAbilityBoxColor;
	private bool isSpellActive;
	private Player player;

	void Start()
	{
		// Store a reference to the ability box Image component
		abilityBoxImage = GetComponent<Image>();
		originalSprite = abilityBoxImage.sprite;

		// Store the original ability box color
		originalAbilityBoxColor = abilityBoxImage.color;

		// Add a click event listener to the ability box
		Button abilityBoxButton = GetComponent<Button>();
		abilityBoxButton.onClick.AddListener(ToggleUnlockedSpells);

		// Add an event trigger for right-clicks to the ability box
		EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener((eventData) => OnPointerClick((PointerEventData)eventData));
		eventTrigger.triggers.Add(entry);

		player = FindObjectOfType<Player>();
	}

	void Update()
	{
		if (FindObjectOfType<Player>().queuedAbility == null)
		{
			abilityBoxImage.color = originalAbilityBoxColor;
			isSpellActive = false;
		}
		if (boundSpellInstance != null)
		{
			// Check if the player has enough ability power for the spell cost
			if (player.currentAbilityPool < boundSpellInstance.abilityPowerCost)
			{
				abilityBoxImage.color = notEnoughPowerColor;
			}
		}
	}

	private void ToggleUnlockedSpells()
	{
		// If a spell is bound to the ability box
		if (boundSpellInstance != null)
		{
			if (player.currentAbilityPool >= boundSpellInstance.abilityPowerCost)
			{
				// If the spell is currently active, unset the player's queued ability and reset the color
				if (isSpellActive)
				{
					FindObjectOfType<Player>().queuedAbility = null;
					abilityBoxImage.color = originalAbilityBoxColor;
					isSpellActive = false;
				}
				else
				{
					// Set the player's queued ability to the bound spell
					FindObjectOfType<Player>().queuedAbility = boundSpellInstance;

					// Change the ability box's appearance to indicate that the spell is active
					abilityBoxImage.color = activeAbilityBoxColor;
					isSpellActive = true;

					if (boundSpellInstance.instantCast)
					{
						Player player = FindObjectOfType<Player>();
						player.queuedAbility.ExecuteSpell(player);
						abilityBoxImage.color = originalAbilityBoxColor;
						isSpellActive = false;
					}
				}
			}
			else
			{
				abilityBoxImage.color = notEnoughPowerColor;
			}

			return;
		}

		// If the panel is already open, close it and return
		if (spellSelectionPanel != null)
		{
			CloseSpellSelectionPanel();
			return;
		}

		// Reset the ability box color to its original color
		abilityBoxImage.color = originalAbilityBoxColor;

		// Get the list of unlocked spells and show the spell selection panel
		List<SpellData> unlockedSpells = FindObjectOfType<SpellManager>().GetUnlockedSpells();
		ShowUnlockedSpells(unlockedSpells);
	}

	private void ShowUnlockedSpells(List<SpellData> unlockedSpells)
	{
		// Create a new panel for displaying the unlocked spells
		spellSelectionPanel = Instantiate(spellSelectionPanelPrefab, FindObjectOfType<Canvas>().transform);

		// Create a UI element for each unlocked spell and add them to the panel
		foreach (SpellData spell in unlockedSpells)
		{
			GameObject spellUI = Instantiate(spellUIPrefab, spellSelectionPanel.transform);
			spellUI.GetComponent<Image>().sprite = spell.uiElement;
			Button spellUIButton = spellUI.GetComponent<Button>();
			spellUIButton.onClick.AddListener(() => BindSpell(spell));
		}
	}

	private void BindSpell(SpellData spell)
	{
		// Bind the selected spell to the ability box
		boundSpellData = spell;
		boundSpellInstance = masterSpellFactory.CreateSpell(spell);

		// Update the ability box UI (e.g., image)
		abilityBoxImage.sprite = boundSpellInstance.uiElement;

		// Close the spell selection panel
		CloseSpellSelectionPanel();
	}

	private void OnPointerClick(PointerEventData eventData)
	{
		// Check for a right-click and if the ability box has a bound ability
		if (eventData.button == PointerEventData.InputButton.Right && boundSpellInstance != null)
		{
			// Clear the bound ability from the ability box
			Destroy(boundSpellInstance.gameObject);
			boundSpellInstance = null;
			boundSpellData = null;

			// Reset the ability box UI (e.g., image) and set the color to the inactive color
			abilityBoxImage.sprite = originalSprite;
			abilityBoxImage.color = originalAbilityBoxColor;
		}
	}

	private void CloseSpellSelectionPanel()
	{
		// Destroy the panel and its UI elements
		Destroy(spellSelectionPanel);
		spellSelectionPanel = null;
	}
}

