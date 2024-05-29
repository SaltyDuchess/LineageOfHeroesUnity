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
		if (player.queuedAbility == null)
		{
			abilityBoxImage.color = originalAbilityBoxColor;
			isAbilityActive = false;
		}

		if (boundAbility != null)
		{
			if (player.currentAbilityPool < boundAbility.abilityPowerCost)
			{
				abilityBoxImage.color = notEnoughPowerColor;
			}

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
	}

	private void ToggleUnlockedAbilities()
	{
		if (boundAbility != null)
		{
			if (player.currentAbilityPool >= boundAbility.abilityPowerCost && boundAbility.currentCooldown == 0)
			{
				if (isAbilityActive)
				{
					player.queuedAbility = null;
					abilityBoxImage.color = originalAbilityBoxColor;
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
					QueueAbility();
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
		if (eventData.button == PointerEventData.InputButton.Right && boundAbility != null)
		{
			Destroy(boundAbility.gameObject);
			boundAbility = null;
			boundAbilityData = null;
			abilityManager.RemoveActiveAbility(boundAbility);
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

		if (boundAbility.instantCast)
		{
			player.queuedAbility.ExecuteAbility(player);
			abilityBoxImage.color = originalAbilityBoxColor;
			isAbilityActive = false;
		}
	}
}
