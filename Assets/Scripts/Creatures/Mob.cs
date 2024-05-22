using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Mob : Creature, IMob
{
	[SerializeField] public CreatureData creatureData;
	public static int instanceCounter = 0;
	public virtual bool isPlayer => false;
	public PhysicsMaterial2D noPushMaterial;
	public string displayName { get; set; }
	public string mobDescription { get; set; }
	private TooltipTrigger tooltipTrigger;

	new protected virtual void Awake()
	{
		base.Awake();
		Mob.instanceCounter++;
		CreatureStats stats = creatureData.stats;

		displayName = creatureData.displayName;
		mobDescription = creatureData.mobDescription;

		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = creatureData.uiElement;
		BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
		collider.size = creatureData.uiElement.bounds.size;
		Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
		rigidBody.gravityScale = 0;
		rigidBody.isKinematic = true;

    // Get the reference to TooltipTrigger component
    tooltipTrigger = GetComponent<TooltipTrigger>();
    if (tooltipTrigger != null)
    {
        // Set the tooltipText using SetTooltipText method
        tooltipTrigger.SetTooltipText(mobDescription);
    }
    else
    {
        Debug.LogWarning("TooltipTrigger component is missing on " + gameObject.name);
    }
	}

	new public void OnTurn()
	{
		// Check if the mob's health is less than or equal to zero
		if (currentHealth <= 0)
		{
			Die();
			return;
		}

		// Implement Mob's AI and behavior during their turn
		// Move towards the player or perform an attack if in range
		MobBehavior mobBehavior = GetComponent<MobBehavior>();
		if (mobBehavior != null)
		{
			mobBehavior.MoveTowardsPlayer(() =>
			{
				// End the turn
				FindObjectOfType<TurnManager>().NextTurn();
			});
		}
	}

	private void Die()
	{
		// Destroy health bar
		if (healthBarObject != null)
		{
			Destroy(healthBarObject);
		}

		// Remove the mob from the TurnManager
		TurnManager turnManager = FindObjectOfType<TurnManager>();
		if (turnManager != null)
		{
			turnManager.RemoveActor(this);
		}

		// Add XP to the player
		Player player = FindObjectOfType<Player>();
		if (player != null)
		{
			player.AddXP(XPValue);
		}

		// Remove the mob from the EnemyManager
		EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
		if (enemyManager != null)
		{
			enemyManager.UnregisterEnemy(this);
		}

		// Destroy the mob instance
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		Mob.instanceCounter--;
	}
}
