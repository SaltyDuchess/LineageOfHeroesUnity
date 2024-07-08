using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
	public class CharacterClass : MonoBehaviour, IClass
	{
		public CharacterClassData classData { get; set; }
		public List<SpellData> classSpells {get; set; }
		public List<PermanentUpgradeData> classPermanentUpgrades { get; set; }
		public string className { get; set; }
		public void ModifyPlayerStats(Player player)
		{}
	}
}
