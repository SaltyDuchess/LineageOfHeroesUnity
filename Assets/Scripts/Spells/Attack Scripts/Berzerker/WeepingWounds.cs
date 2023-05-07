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

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * physDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.physDamageResist;

			defender.stats.currentHealth -= damage;

			defender.stats.damageOverTime = DOT;
			defender.stats.damageOverTimeTurns = DOTTurns;
		}
	}
}
