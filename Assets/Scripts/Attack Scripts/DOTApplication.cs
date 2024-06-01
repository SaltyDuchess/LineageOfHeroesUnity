namespace LineageOfHeroes.AttackScripts
{
	public static class DOTApplication
	{
		public static void ApplyBleedToDefender(Creature defender, float bleedAmount, int bleedTurns)
		{
			defender.damageOverTime = bleedAmount;
			defender.damageOverTimeTurns = bleedTurns;
		}
	}
}