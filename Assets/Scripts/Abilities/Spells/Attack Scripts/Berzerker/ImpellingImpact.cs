using LineageOfHeroes.AttackScripts;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class ImpellingImpact : BerzerkerSpellBase
	{
		[SerializeField] protected int pushDistance = 4;
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals a regular melee attack and pushes the targeted enemy away by {pushDistance} squares.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);

			if (defender != null)
			{
				// Perform regular melee attack
				DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, defender);

				// Push the defender away by 3 squares
				MoveTarget.PushTargetAway(castingCreature, defender, pushDistance);
			}
		}
	}
}
