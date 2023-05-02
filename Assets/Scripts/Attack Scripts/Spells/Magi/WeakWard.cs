namespace LineageOfHeroes.Spells.Magi
{
	public class WeakWard : SpellBase, ISpell
	{
		override public void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteSpell(castingCreature, defender);

			if (castingCreature.stats.invulnerabilityCharges == 0)
			{
				castingCreature.stats.invulnerabilityCharges += 1;
			}
			castingCreature.queuedAbility = null;
		}
	}
}
