using LineageOfHeroes.SpellFactory;
using LineageOfHeroes.Spells;
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

		// Iterate through the player's class spells and create a UI object for each one
		foreach (SpellData spell in player.playerClass.classSpells)
		{
			if (spell == null)
			{
				Debug.LogError("A spell in the player's class spells is null.");
				continue;
			}

			SpellBase spellInstance = spellFactory.CreateSpell(spell);
			if (spellInstance == null)
			{
				Debug.LogError($"Failed to create spell instance for {spell.spellName}");
				continue;
			}
			GameObject spellUI = Instantiate(spellLevelUpPrefab);

			if (spellUI == null)
			{
				Debug.LogError("Failed to instantiate spellLevelUpPrefab");
				continue;
			}
			spellUI.transform.SetParent(overlay.transform.Find("SpellUILevelupLayout").transform, false);

			// Set the properties of the spell UI object (e.g., image, text)
			spellUI.GetComponent<Image>().sprite = spellInstance.uiElement;
			// Get the reference to TooltipTrigger component
			tooltipTrigger = spellUI.GetComponent<TooltipTrigger>();

			if (tooltipTrigger == null)
			{
				Debug.LogError("Failed to get TooltipTrigger component from spellUI");
				continue;
			}

			// Set the tooltipText using SetTooltipText method
			tooltipTrigger.SetTooltipText(spellInstance.descriptionLong);
		}
	}

}
