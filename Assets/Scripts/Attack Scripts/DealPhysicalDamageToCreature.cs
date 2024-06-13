
using UnityEngine;

namespace LineageOfHeroes.AttackScripts
{
	public static class DealPhysicalDamageToCreature
	{
		public static float DealPhysicalDamage(Creature castingCreature, Creature defender, float physDamageModifier = 0)
		{
			float damage = castingCreature.damageRange.GetRandomValue();

			damage += damage * physDamageModifier;

			damage *= CalcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.physDamageResist / 100;

			defender.currentHealth -= damage;

			if (castingCreature is Player)
			{
				Debug.Log($"Player dealt  {damage} damage to {defender.name}");
			}

			return damage;
		}
	}
}