using UnityEngine;
using LineageOfHeroes.LootSystem;
using LineageOfHeroes.Items;

public class Chest : MonoBehaviour
{
	[SerializeField] public LootTable lootTable; // assign in inspector
	[SerializeField] private Sprite openedChestSprite; // assign in inspector
	[SerializeField] private Sprite closedChestSprite; // assign in inspector

	private LootManager lootManager;
	private PlayerInventory playerInventory;
	private bool isOpened = false;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		lootManager = FindObjectOfType<LootManager>();
		playerInventory = FindObjectOfType<Player>().GetComponent<PlayerInventory>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = closedChestSprite; // start with closed chest sprite
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!isOpened && other.gameObject.CompareTag("Player"))
		{
			isOpened = true;
			lootManager.GenerateLootFromTable(lootTable, playerInventory);
			spriteRenderer.sprite = openedChestSprite; // switch to opened chest sprite
			// Add animations or effects for opening the chest
		}
	}
}
