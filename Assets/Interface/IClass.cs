using System.Collections.Generic;

namespace LineageOfHeroes.CharacterClasses
{
	public interface IClass
	{
		CharacterClassData classData { get; set; }
		List<SpellData> classSpells { get; set; }
		public string className { get; set; }
		public abstract void ModifyPlayerStats(Player player);
	}
}
