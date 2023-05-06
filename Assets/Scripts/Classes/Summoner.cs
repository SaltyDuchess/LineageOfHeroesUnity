namespace LineageOfHeroes.CharacterClasses
{
	public class Summoner : CharacterClass
	{
		public CharacterClassData summonerCharacterClassData;
		private void Awake()
		{
			classSpells = summonerCharacterClassData.classSpellLibrary.classSpells;
		}
		new public void ModifyPlayerStats(Player player)
		{
		}
	}
}
