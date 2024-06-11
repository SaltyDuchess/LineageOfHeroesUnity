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
	private MobBehavior mobBehavior;
	private TurnManager turnManager;
	private Player player;

	new protected virtual void Awake()
	{
		stats = creatureData.stats;
		base.Awake();
		Mob.instanceCounter++;

		displayName = creatureData.displayName;
		mobDescription = $"{creatureData.mobDescription}\n{creatureData.displayName} - Level {creatureData.stats.currentLevel}";

		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = creatureData.uiElement;
		BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
		Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
		rigidBody.gravityScale = 0;
		rigidBody.isKinematic = true;

		tooltipTrigger = GetComponent<TooltipTrigger>();
		if (tooltipTrigger != null)
		{
			tooltipTrigger.SetTooltipText(mobDescription);
		}
		else
		{
			Debug.LogWarning("TooltipTrigger component is missing on " + gameObject.name);
		}

		mobBehavior = GetComponent<MobBehavior>();
		turnManager = FindObjectOfType<TurnManager>();
		player = FindObjectOfType<Player>();
	}

	new public void OnTurn()
	{
		base.OnTurn();
		if (currentHealth <= 0)
		{
			Die();
			return;
		}

		if (mobBehavior != null)
		{
			if (mobBehavior.IsPlayerInRange(autoAttackRange))
			{
				mobBehavior.PerformAttack();
			}
			else
			{
				mobBehavior.MoveTowardsPlayer(() =>
				{
					turnManager.NextTurn();
				});
			}
		}
	}

	private void Die()
	{
		if (healthBarObject != null)
		{
			Destroy(healthBarObject);
		}

		if (turnManager != null)
		{
			turnManager.RemoveActor(this);
		}

		if (player != null)
		{
			player.AddXP(XPValue);
		}

		EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
		if (enemyManager != null)
		{
			enemyManager.UnregisterEnemy(this);
		}

		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		Mob.instanceCounter--;
	}
}
