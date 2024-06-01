namespace LineageOfHeroes.AttackScripts
{
	public static class DealMagicDamageToCreature
	{
			public static float DealMagicDamage(Creature castingCreature, Creature defender, float magicDamageModifier)
			{
					float damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * magicDamageModifier;
					damage *= CalcCritAndDamage.CalculateCritAndDamage(castingCreature);

					damage -= damage * defender.magicDamageResist;

					defender.currentHealth -= damage;

					return damage;
			}

			public static void DealGlobalAOEMagicDamage(Creature castingCreature, Creature[] defenders, float magicDamageModifier)
			{
				float damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * magicDamageModifier;
				damage *= CalcCritAndDamage.CalculateCritAndDamage(castingCreature);

				foreach (Creature defender in defenders)
				{
						float finalDamage = damage - (damage * defender.magicDamageResist);
						defender.currentHealth -= finalDamage;
				}
			}
	}
}