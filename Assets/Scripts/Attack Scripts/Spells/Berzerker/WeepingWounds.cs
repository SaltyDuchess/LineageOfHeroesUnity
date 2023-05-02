using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class WeepingWounds : SpellBase, ISpell
	{
		[SerializeField] private Player player;

		new private void Awake()
		{
			base.Awake();
			DOT = (float)(player.stats.GetDamageValue() * .5);
			physDamageModifier = -0.1f;
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.stats.GetDamageValue() + castingCreature.stats.GetDamageValue() * physDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.physDamageResist;

			defender.stats.currentHealth -= damage;

			defender.stats.damageOverTime = DOT;
			defender.stats.damageOverTimeTurns = DOTTurns;
		}
	}
}
