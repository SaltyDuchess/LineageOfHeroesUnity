namespace LineageOfHeroes.Spells.Magi
{
	public class WeakWard : SpellBase, ISpell
	{
			public void WeakWardScript(Creature castingCreature)
			{
					castingCreature.currentAbilityPool -= abilityPowerCost;

					if (castingCreature.invulnerabilityCharges == 0)
					{
							castingCreature.invulnerabilityCharges += 1;
					}

					currentCooldown = cooldown;
					castingCreature.queuedAbility = null;
			}
	}
}
