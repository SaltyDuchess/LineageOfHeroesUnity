namespace LineageOfHeroes.CharacterClasses
{
	public class Magi : CharacterClass
	{
		public CharacterClassData magiClassData;
		private void Awake()
		{
			classSpells = magiClassData.classSpellLibrary.classSpells;
		}
		new public void ModifyPlayerStats(Player player)
		{
		}
	}
}
