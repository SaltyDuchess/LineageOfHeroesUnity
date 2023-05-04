using UnityEngine;

public class Mob : MonoBehaviour, IMob, ICreature
{
	[SerializeField] public CreatureData creatureData;
	public virtual bool isPlayer => false;
	public PhysicsMaterial2D noPushMaterial;
	public int level { get; set; }
	public float healthPool { get; set; }
	public float currentHealth { get; set; }
	public float percentageHealth { get; set; }
	public int xPValue { get; set; }
	public float speedPool { get; set; }
	public float abilityPowerPool { get; set; }
	public float currentAbilityPool { get; set; }
	public float percentageAbilityPool { get; set; }
	public float abilityRegeneration { get; set; }
	public float dodgeChance { get; set; }
	public float physDamageResist { get; set; }
	public float magicDamageResist { get; set; }
	public float invulnerabilityCharges { get; set; }
	public float autoAttackRange { get; set; }
	public float actionSpeedCost { get; set; }
	public float damageOverTime { get; set; }
	public int damageOverTimeTurns { get; set; }
	public StatRange damageRange { get; set; }
	public float healthRegeneration { get; set; }
	public float critDamageMultiplier { get; set; }
	public float critChanceModifier { get; set; }
	public string displayName { get; set; }
	public string mobDescription { get; set; }

	protected virtual void Awake()
	{
		CreatureStats stats = creatureData.stats;

		displayName = creatureData.displayName;
		mobDescription = creatureData.mobDescription;
		level = stats.currentLevel;
		healthPool = stats.healthPool;
		currentHealth = stats.currentHealth;
		percentageHealth = stats.percentageHealth;
		xPValue = stats.XPValue;
		speedPool = stats.speedPool;
		abilityPowerPool = stats.abilityPowerPool;
		currentAbilityPool = stats.currentAbilityPool;
		percentageAbilityPool = stats.percentageAbilityPool;
		abilityRegeneration = stats.abilityRegeneration;
		dodgeChance = stats.dodgeChance;
		physDamageResist = stats.physDamageResist;
		magicDamageResist = stats.magicDamageResist;
		invulnerabilityCharges = stats.invulnerabilityCharges;
		autoAttackRange = stats.autoAttackRange;
		actionSpeedCost = stats.actionSpeedCost;
		damageOverTime = stats.damageOverTime;
		damageOverTimeTurns = stats.damageOverTimeTurns;
		damageRange = stats.damageRange;
		healthRegeneration = stats.healthRegeneration;
		critDamageMultiplier = stats.critDamageMultiplier;
		critChanceModifier = stats.critChanceModifier;

		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = creatureData.uiElement;
		BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
		Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
		rigidBody.gravityScale = 0;
		rigidBody.isKinematic = true;
	}

	public void OnTurn()
	{
		// Implement Mob's AI and behavior during their turn
		// Move towards the player or perform an attack if in range
    MobBehavior mobBehavior = GetComponent<MobBehavior>();
    if (mobBehavior != null)
    {
        mobBehavior.MoveTowardsPlayer(() => {
            // End the turn
            speedPool -= this.creatureData.stats.actionSpeedCost;
            FindObjectOfType<TurnManager>().NextTurn();
        });
    }
	}

}
