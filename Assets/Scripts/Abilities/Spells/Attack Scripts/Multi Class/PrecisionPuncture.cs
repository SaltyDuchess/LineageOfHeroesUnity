using LineageOfHeroes.AttackScripts;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class PrecisionPuncture : SpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Guarantees the next attack will be a critical hit.";
		}

		public override void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			GlobalCombatFlags.Instance.playerCritQueued = true;
			Debug.Log("Precision Puncture cast. playerCritQueued set to true.");
		}
	}
}
