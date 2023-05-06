using System.Collections.Generic;
using LineageOfHeroes.Spells;

namespace LineageOfHeroes.CharacterClasses
{
	public interface IClass
	{
		CharacterClassData classData { get; set; }
		List<SpellBase> classSpells { get; set; }
		public string className { get; set; }
		public abstract void ModifyPlayerStats(Player player);
	}
}
