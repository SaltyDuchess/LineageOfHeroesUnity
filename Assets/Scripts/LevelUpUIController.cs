using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Spells;
using UnityEngine;

public class LevelUpUIController : MonoBehaviour
{
	public GameObject abilityPointIndicatorPrefab;
	public GameObject overlayPrefab;
	public GameObject spellPrefab;

	private Player player;
	private GameObject abilityPointIndicator;
	private GameObject overlay;

	void Awake()
	{
		player = FindObjectOfType<Player>();
		abilityPointIndicator = Instantiate(abilityPointIndicatorPrefab, FindObjectOfType<Canvas>().transform);
		abilityPointIndicator.SetActive(false);
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
		// Instantiate the overlay
		overlay = Instantiate(overlayPrefab, FindObjectOfType<Canvas>().transform);

		// Iterate through the player's class spells and create a UI object for each one
		foreach (SpellBase spell in player.playerClass.classSpells)
		{
			Debug.Log(spell.displayName);
			GameObject spellUI = Instantiate(spellPrefab, overlay.transform);
			// Set the properties of the spell UI object (e.g., image, text)
		}
	}

}
