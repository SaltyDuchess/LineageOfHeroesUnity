using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
	public class CharacterClass : MonoBehaviour, IClass
	{
		public CharacterClassData classData { get; set; }
		public List<SpellBase> classSpells {get; set; }
		public string className { get; set; }
		public void ModifyPlayerStats(Player player)
		{}
	}
}
