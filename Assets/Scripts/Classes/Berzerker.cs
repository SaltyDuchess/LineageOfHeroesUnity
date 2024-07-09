using LineageOfHeroes.CodingUtilityScripts;

namespace LineageOfHeroes.CharacterClasses
{
	public class Berzerker : CharacterClass
	{
		public CharacterClassData berzerkerCharacterClassData;
		private void Awake()
		{
			classSpells = berzerkerCharacterClassData.classSpellLibrary.classSpells;
			ListUtilities.AddUniqueRangeToList(classSpells, berzerkerCharacterClassData.multiClassSpellLibrary.classSpells);
			classPermanentUpgrades = new System.Collections.Generic.List<PermanentUpgradeData>();
			ListUtilities.AddUniqueRangeToList(classPermanentUpgrades, berzerkerCharacterClassData.classPermanentUpgradeLibrary.classPermanentUpgrades);
			ListUtilities.AddUniqueRangeToList(classPermanentUpgrades, berzerkerCharacterClassData.multiClassPermanentUpgradeLibrary.classPermanentUpgrades);
			this.ModifyPlayerStats(FindObjectOfType<Player>());
		}

		new public void ModifyPlayerStats(Player player)
		{
			base.ModifyPlayerStats(player);
			// Example: Add 50 health points for Berzerker class
			player.healthPool += 50;
			player.currentHealth = player.healthPool;
		}
	}
}
