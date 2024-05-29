using UnityEngine;

public class HealingHootch : PotionBase
{
		[SerializeField] private int healingValue;
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - Free Instant Cast --- Required Level - {levelRequirement}\nDescription - Heals the player for {healingValue} health.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature);
			castingCreature.currentHealth += healingValue;
		}
}
