namespace LineageOfHeroes.Spells.Summoner
{
	public class MeaslyMiasma : SpellBase, ISpell
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 1;
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.stats.GetDamageValue() + castingCreature.stats.GetDamageValue() * magicDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			Mob[] mobs = FindObjectsOfType<Mob>();

			foreach (Mob mob in mobs)
			{
				float finalDamage = damage - (damage * mob.stats.magicDamageResist);
				mob.stats.currentHealth -= finalDamage;
			}
		}
	}
}
