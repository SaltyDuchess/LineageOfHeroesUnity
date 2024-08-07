using System.Collections.Generic;
using LineageOfHeroes.AttackScripts;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{
	public bool IsPlayer;
	public IAbility queuedAbility { get; set; } = null;
	public CreatureStats stats = new CreatureStats();
	public float speedPool { get; set; }
	public float currentSpeedPool { get; set; }
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
	public List<DOTData> damageOverTimeEffects { get; set; }
	public StatRange damageRange { get; set; }
	public float healthRegeneration { get; set; }
	public float critDamageMultiplier { get; set; }
	public float critChanceModifier { get; set; }
	public int currentLevel { get; set; } = 1;
	public float percentageHealth { get; set; } = 100;
	public int XPValue { get; set; } = 5;
	public GameObject healthBarObject { get; set; }
	public int movementDisabledTurns { get; set; } = 0;

	protected virtual void Awake()
	{
		AssignStatsFromCreatureStats(stats);
		damageOverTimeEffects = new List<DOTData>();
	}

	private void Update()
	{
		percentageHealth = (currentHealth / healthPool) * 100;
		percentageAbilityPool = (currentAbilityPool / abilityPowerPool) * 100;
	}

	protected void AssignStatsFromCreatureStats(CreatureStats stats)
	{
		speedPool = stats.speedPool;
		currentSpeedPool = stats.currentSpeedPool;
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
		damageRange = stats.damageRange;
		healthRegeneration = stats.healthRegeneration;
		critDamageMultiplier = stats.critDamageMultiplier;
		critChanceModifier = stats.critChanceModifier;
		currentLevel = stats.currentLevel;
		percentageHealth = stats.percentageHealth;
		XPValue = stats.XPValue;
	}

	public virtual void OnTurn()
	{
		if (currentAbilityPool < abilityPowerPool)
		{
			currentAbilityPool += abilityRegeneration;
		}
		if (damageOverTimeEffects.Count > 0)
		{
			DealDOTDamageToCreature.DealDOTDamage(this);
		}
		if (currentHealth < healthPool)
		{
			currentHealth += healthRegeneration;
		}
		if (movementDisabledTurns > 0)
		{
			movementDisabledTurns--;
		}
	}

	public bool TryAttack(Creature target)
	{
		if (target == null) return false;

		// Apply invulnerability charges if the target has any
		if (target.invulnerabilityCharges > 0)
		{
			target.invulnerabilityCharges--;
			return true;
		}

		// if the creature has a queued ability, trigger the ability rather than the auto attack
		if (queuedAbility != null)
		{
			queuedAbility.ExecuteAbility(this, target);
			return true;
		}

		DealPhysicalDamageToCreature.DealPhysicalDamage(this, target);

		// Return true if an attack has been performed
		return true;
	}

	public static Creature GetCreatureAtGridPosition(Vector2Int gridPosition)
	{
		// Convert grid position to world position
		Vector3 worldPosition = new Vector3(gridPosition.x, gridPosition.y, 0);

		// Cast a ray at the world position to detect colliders
		RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 0f);

		// If a collider is hit, try to get the ICreature component
		if (hit.collider != null)
		{
			return hit.collider.GetComponent<Creature>();
		}

		return null;
	}
}
