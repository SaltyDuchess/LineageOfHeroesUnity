namespace LineageOfHeroes.AttackScripts
{
	public static class DOTApplication
	{
		public static void ApplyBleedToDefender(Creature defender, float bleedAmount, int bleedTurns)
		{
			defender.damageOverTimeEffects.Add(new DOTData
			{ 
				dotType = DOTType.Bleed,
				dotAmount = bleedAmount,
				dotTurns = bleedTurns
			});
		}
	}
}