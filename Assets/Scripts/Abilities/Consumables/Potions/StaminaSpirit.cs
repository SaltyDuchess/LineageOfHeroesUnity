
using UnityEngine;

public class StaminaSpirit : PotionBase
{
		[SerializeField] private int staminaValue;
    new private void Awake()
		{
				base.Awake();
				descriptionLong = $"{displayName} --- Cost - Free Instant Cast --- Required Level - {levelRequirement}\nDescription - Restores {staminaValue} stamina.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
				base.ExecuteAbility(castingCreature);
				castingCreature.currentAbilityPool += staminaValue;
		}
}
