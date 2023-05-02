namespace LineageOfHeroes.Spells.Berzerker
{
	public class StunningStrike : SpellBase, ISpell
	{
		new private void Awake()
		{
			base.Awake();
			physDamageModifier = 0;
			stunTurns = 2;
		}

		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);
			float damage;

			damage = castingCreature.stats.GetDamageValue() + castingCreature.stats.GetDamageValue() * physDamageModifier;
			damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);

			damage -= damage * defender.stats.physDamageResist;

			defender.stats.currentHealth -= damage;

			defender.stats.speedPool -= stunTurns * 100;
		}
	}
}
