namespace LineageOfHeroes.Spells.Summoner
{
	public class MeaslyMiasma : SummonerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 1;
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to all enemies";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			float damage;

			damage = castingCreature.damageRange.GetRandomValue() + castingCreature.damageRange.GetRandomValue() * magicDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			Mob[] mobs = FindObjectsOfType<Mob>();

			foreach (Mob mob in mobs)
			{
				float finalDamage = damage - (damage * mob.magicDamageResist);
				mob.currentHealth -= finalDamage;
			}
		}
	}
}
