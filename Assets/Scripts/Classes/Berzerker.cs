using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
	public class Berzerker : CharacterClass
	{
		public CharacterClassData berzerkerCharacterClassData;
		private void Awake()
		{
			classSpells = berzerkerCharacterClassData.classSpellLibrary.classSpells;
			this.ModifyPlayerStats(FindObjectOfType<Player>());
		}
		new public void ModifyPlayerStats(Player player)
		{
			base.ModifyPlayerStats(player);
		  Debug.Log("hello");
			// Example: Add 50 health points for Berzerker class
			player.healthPool += 50;
			player.currentHealth = player.healthPool;
		}
	}
}
