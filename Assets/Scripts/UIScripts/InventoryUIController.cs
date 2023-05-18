using LineageOfHeroes.ItemFactories;
using LineageOfHeroes.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
	public GameObject inventoryPanel;
	public GameObject itemUIBoxPrefab;
	public PlayerInventory playerInventory;
	public PlayerEquipment playerEquipment;

	private ItemFactory itemFactory;
	private TooltipTrigger tooltipTrigger;

	private bool isInventoryOpen = false;

	void Awake()
	{
		itemFactory = FindObjectOfType<ItemFactory>();
		inventoryPanel.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			isInventoryOpen = !isInventoryOpen;
			inventoryPanel.SetActive(isInventoryOpen);

			if (isInventoryOpen)
			{
				UpdateInventoryUI();
			}
		}
	}

	private void UpdateInventoryUI()
	{
		// Clear out old items
		foreach (Transform child in inventoryPanel.transform)
		{
			Destroy(child.gameObject);
		}

		// Add new items
		foreach (EquipmentData item in playerInventory.InventoryList)
		{
			GameObject newItemUIBox = Instantiate(itemUIBoxPrefab, inventoryPanel.transform);

			EquipmentBase itemInstance = itemFactory.CreateItem(item);
			itemInstance.transform.SetParent(inventoryPanel.transform);
			newItemUIBox.GetComponent<Image>().sprite = itemInstance.uiElement;

			// Add button listener
			Button button = newItemUIBox.GetComponent<Button>();
			button.onClick.AddListener(() => playerEquipment.EquipItem(itemInstance));

			// Get the reference to TooltipTrigger component
			tooltipTrigger = newItemUIBox.GetComponent<TooltipTrigger>();

			// Set the tooltipText using SetTooltipText method
			tooltipTrigger.SetTooltipText(itemInstance.descriptionLong);
		}
	}
}
