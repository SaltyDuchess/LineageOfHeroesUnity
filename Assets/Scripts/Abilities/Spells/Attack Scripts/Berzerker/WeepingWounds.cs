using LineageOfHeroes.AttackScripts;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class WeepingWounds : BerzerkerSpellBase
	{
		private Player player;

		new private void Awake()
		{
			player = FindObjectOfType<Player>();
			base.Awake();
			DOT = (float)(player.damageRange.GetRandomValue() * .5);
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {physDamageModifier * 100}% physical damage and applies {DOT} damage over time for {DOTTurns} turns";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, defender, spellData.physDamageModifier);
			DOTApplication.ApplyBleedToDefender(defender, DOT, DOTTurns);
		}
	}
}
