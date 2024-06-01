namespace LineageOfHeroes.AttackScripts
{
	public static class DealPhysicalDamageToCreature
	{
		public static float DealPhysicalDamage(Creature castingCreature, Creature defender, float physDamageModifier)
		{
			float damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * physDamageModifier;
			damage *= CalcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.physDamageResist;

			defender.currentHealth -= damage;

			return damage;
		}
	}
}