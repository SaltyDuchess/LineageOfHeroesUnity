using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{
	public bool IsPlayer;
	public IAbility queuedAbility { get; set; } = null;
	public CreatureStats stats = new CreatureStats();
	public float speedPool { get; set; }
	public float healthPool { get; set; } = 100;
	public float currentHealth { get; set; } = 100;
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
	public CalcCritAndDamage critAndDamageCalculator { get; set; }
	public int currentLevel { get; set; } = 1;
	public float percentageHealth { get; set; } = 100;
	public int XPValue { get; set; } = 5;
	public GameObject healthBarObject { get; set; }

	protected virtual void Awake()
	{
		AssignStatsFromCreatureStats(stats);
	}

	protected void AssignStatsFromCreatureStats(CreatureStats stats)
	{
		speedPool = stats.speedPool;
		healthPool = stats.healthPool;
		currentHealth = stats.currentHealth;
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
		currentLevel = stats.currentLevel;
		percentageHealth = stats.percentageHealth;
		XPValue = stats.XPValue;
	}

	public void OnTurn()
	{
	}

	public bool TryAttack(ICreature target)
	{
		if (target == null) return false;

		// Calculate the damage based on the damage range
		float damage = damageRange.GetRandomValue();

		// Apply critical hit multiplier if applicable
		damage *= FindObjectOfType<CalcCritAndDamage>().CalculateCritAndDamage(this);

		// Apply damage reduction based on the target's physical damage resistance
		damage -= damage * (target.physDamageResist / 100);

		// Apply invulnerability charges if the target has any
		if (target.invulnerabilityCharges > 0)
		{
			target.invulnerabilityCharges--;
		}
		else
		{
			// Deal damage to the target
			target.currentHealth -= damage;
			target.currentHealth = Mathf.Max(0, target.currentHealth);
		}

		// Return true if an attack has been performed
		return true;
	}

	public static ICreature GetCreatureAtGridPosition(Vector2Int gridPosition)
	{
		// Convert grid position to world position
		Vector3 worldPosition = new Vector3(gridPosition.x, gridPosition.y, 0);

		// Cast a ray at the world position to detect colliders
		RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 0f);

		// If a collider is hit, try to get the ICreature component
		if (hit.collider != null)
		{
			return hit.collider.GetComponent<ICreature>();
		}

		return null;
	}
}
