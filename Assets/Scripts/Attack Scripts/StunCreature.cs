namespace LineageOfHeroes.AttackScripts
{
	public static class StunCreature
	{
		public static void StunDefender(Creature defender, float stunTurns)
		{
			defender.currentSpeedPool -= stunTurns * 100;
		}
	}
}