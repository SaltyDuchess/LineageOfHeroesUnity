using LineageOfHeroes.Spells.Berzerker;
using UnityEngine;

public class RavagingRejuvenation : BerzerkerPermanentUpgradeBase
{
	[SerializeField] private float enemyHpDrain = 5f;
	[SerializeField] private float radius = 3f;
	[SerializeField] private GameObject aoeCirclePrefab; // Prefab for the aoe circle
	[SerializeField] private int zAxisForRedCircle = 25;
	private Player player;

	protected override void Awake()
	{
		base.Awake();
		player = FindObjectOfType<Player>();
		descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Drains {enemyHpDrain} health from all enemies within a {radius} unit radius of the player and adds it to the player's ability pool each turn.";
		DisplayRedCircle();
	}

	public override void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
	{
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.transform.position, radius);
		var totalDrain = 0f;

		foreach (var hitCollider in hitColliders)
		{
			Mob mob = hitCollider.GetComponent<Mob>();
			if (mob != null)
			{
				mob.currentHealth -= enemyHpDrain;
				totalDrain += enemyHpDrain;
			}
		}

		player.currentAbilityPool += totalDrain;
	}

	public override bool IsCastable(Creature castingCreature = null)
	{
		return true;
	}

	private void DisplayRedCircle()
	{
		GameObject redCircle = Instantiate(aoeCirclePrefab, player.transform.position, Quaternion.identity);
		redCircle.transform.SetParent(player.transform);
		redCircle.transform.position = new Vector3(redCircle.transform.position.x, redCircle.transform.position.y, zAxisForRedCircle);
		redCircle.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f); // Semi-transparent red
	}

	private void OnDrawGizmosSelected()
	{
		if (player == null) return;
		Gizmos.color = new Color(1, 0, 0, 0.5f); // Semi-transparent red
		Gizmos.DrawSphere(player.transform.position, radius);
	}
}
