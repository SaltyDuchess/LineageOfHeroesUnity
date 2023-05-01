namespace LineageOfHeroes.Spells.Magi
{
	public class WeakWard : SpellBase, ISpell
	{
			public void WeakWardScript(ICreature castingICreature)
			{
					castingICreature.currentAbilityPool -= abilityPowerCost;

					if (castingICreature.invulnerabilityCharges == 0)
					{
							castingICreature.invulnerabilityCharges += 1;
					}

					currentCooldown = cooldown;
					castingICreature.queuedAbility = null;
			}
	}
}
