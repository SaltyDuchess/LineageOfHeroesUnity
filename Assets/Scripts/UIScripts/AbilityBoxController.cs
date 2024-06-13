using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.Spells;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityBoxController : MonoBehaviour
{
	public GameObject abilityUIPrefab;
	public GameObject abilitySelectionPanelPrefab;
	public GameObject cooldownUIPrefab;
	public AbilityFactory masterAbilityFactory;
	public Color activeAbilityBoxColor = Color.yellow;
	public Color notEnoughPowerColor = new Color(1, 0, 0, 0.3f);

	private AbilityManager abilityManager;
	private AbilityBase boundAbility;
	private GameObject instantiatedAbility;
	private AbilityData boundAbilityData;
	private GameObject abilitySelectionPanel;
	private Image abilityBoxImage;
	private Sprite originalSprite;
	private Color originalAbilityBoxColor;
	private bool isAbilityActive;
	private Player player;
	private PlayerInventory playerInventory;
	private GameObject cooldownUIInstance;

	void Awake()
	{
		abilityBoxImage = GetComponent<Image>();
		originalSprite = abilityBoxImage.sprite;
		originalAbilityBoxColor = abilityBoxImage.color;

		Button abilityBoxButton = GetComponent<Button>();
		abilityBoxButton.onClick.AddListener(ToggleUnlockedAbilities);

		EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener((eventData) => OnPointerClick((PointerEventData)eventData));
		eventTrigger.triggers.Add(entry);

		abilityManager = FindObjectOfType<AbilityManager>();
		player = FindObjectOfType<Player>();
		playerInventory = player.GetComponent<PlayerInventory>();
	}

	void Update()
	{
		UpdateAbilityBoxColor();

		if (player.queuedAbility == null && boundAbility == null)
		{
			abilityBoxImage.color = originalAbilityBoxColor;
			isAbilityActive = false;
		}

		if (boundAbility != null)
		{
			if (boundAbility.currentCooldown > 0)
			{
				abilityBoxImage.color = notEnoughPowerColor;
				if (cooldownUIInstance == null)
				{
					cooldownUIInstance = Instantiate(cooldownUIPrefab, transform);
					CooldownController cooldownController = cooldownUIInstance.GetComponent<CooldownController>();
					cooldownController.associatedAbility = boundAbility;
				}
			}

			if (boundAbility is ConsumableBase consumable)
			{
				ConsumableData consumableData = playerInventory.ConsumableList.Find(c => c.displayName == consumable.displayName);
				if (consumableData.quantity == 0)
				{
					abilityBoxImage.color = notEnoughPowerColor;
					isAbilityActive = false;
				}
			}
		}

		// Handle targeted spell input
		if (boundAbility is TargetedSpellBase targetedSpell && isAbilityActive)
		{
			if (!targetedSpell.selectedTarget)
			{
				targetedSpell.SelectNextTarget();
			}
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				targetedSpell.SelectNextTarget();
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				targetedSpell.ConfirmTargetAndCast();
			}
		}
	}

	private void UpdateAbilityBoxColor()
	{
		if (boundAbility != null)
		{
			if (!boundAbility.IsCastable(player))
			{
				abilityBoxImage.color = notEnoughPowerColor;
			}
			else if (isAbilityActive || abilityManager.GetActiveSustainedSpells().Contains((SpellBase)boundAbility))
			{
				return;
			}
			else
			{
				abilityBoxImage.color = originalAbilityBoxColor;
			}
		}
	}

	private void ToggleUnlockedAbilities()
	{
		if (boundAbility != null)
		{
			if (boundAbility.IsCastable(player) && boundAbility.currentCooldown == 0)
			{
				if (isAbilityActive)
				{
					if (boundAbility.isSustainedSpell)
					{
						// Toggle sustained spell off
						abilityManager.RemoveSustainedSpell((SpellBase)boundAbility);
					}
					abilityBoxImage.color = originalAbilityBoxColor;
					player.queuedAbility = null;
					isAbilityActive = false;
				}
				else if (boundAbility is ConsumableBase consumable)
				{
					ConsumableData consumableData = playerInventory.ConsumableList.Find(c => c.displayName == consumable.displayName);
					if (consumableData.quantity > 0)
					{
						QueueAbility();
					}
				}
				else
				{
					if (boundAbility.isSustainedSpell)
					{
						// Toggle sustained spell on
						isAbilityActive = true;
						abilityManager.AddSustainedSpell((SpellBase)boundAbility);
						abilityBoxImage.color = activeAbilityBoxColor;
					}
					else
					{
						QueueAbility();
					}
				}
			}
			else
			{
				abilityBoxImage.color = notEnoughPowerColor;
			}

			return;
		}

		if (abilitySelectionPanel != null)
		{
			CloseAbilitySelectionPanel();
			return;
		}

		abilityBoxImage.color = originalAbilityBoxColor;

		List<AbilityData> unlockedAbilities = abilityManager.GetUnlockedAbilities();
		ShowUnlockedAbilities(unlockedAbilities);
	}

	private void ShowUnlockedAbilities(List<AbilityData> unlockedAbilities)
	{
		abilitySelectionPanel = Instantiate(abilitySelectionPanelPrefab, FindObjectOfType<Canvas>().transform);

		foreach (AbilityData ability in unlockedAbilities)
		{
			GameObject abilityUI = Instantiate(abilityUIPrefab, abilitySelectionPanel.transform);
			abilityUI.GetComponent<Image>().sprite = ability.uiElement;
			Button abilityUIButton = abilityUI.GetComponent<Button>();
			abilityUIButton.onClick.AddListener(() => BindAbility(ability));
		}
	}

	private void BindAbility(AbilityData abilityData)
	{
		boundAbilityData = abilityData;
		boundAbility = masterAbilityFactory.CreateAbility(abilityData);
		abilityBoxImage.sprite = boundAbility.uiElement;

		abilityManager.AddActiveAbility(boundAbility);

		CloseAbilitySelectionPanel();
	}

	private void OnPointerClick(PointerEventData eventData)
	{
		// this is what is called when the user right clicks on an ability box to remove an ability
		if (eventData.button == PointerEventData.InputButton.Right && boundAbility != null)
		{
			if (boundAbility.isSustainedSpell && isAbilityActive)
			{
				abilityManager.RemoveSustainedSpell((SpellBase)boundAbility);
			}
			abilityManager.RemoveActiveAbility(boundAbility);
			Destroy(boundAbility.gameObject); // with this logic the user can right click cheese to reset cooldowns, needs fix eventually
			boundAbility = null;
			boundAbilityData = null;
			abilityBoxImage.sprite = originalSprite;
			abilityBoxImage.color = originalAbilityBoxColor;
		}
	}

	private void CloseAbilitySelectionPanel()
	{
		Debug.Log("Closing ability selection panel");
		Debug.Log(abilitySelectionPanel);
		Destroy(abilitySelectionPanel);
		abilitySelectionPanel = null;
	}

	private void QueueAbility()
	{
		player.queuedAbility = boundAbility;
		abilityBoxImage.color = activeAbilityBoxColor;
		isAbilityActive = true;

		if (boundAbility.instantCast && !(boundAbility is TargetedSpellBase))
		{
			player.queuedAbility.ExecuteAbility(player);
			abilityBoxImage.color = originalAbilityBoxColor;
			isAbilityActive = false;
		}
	}
}
