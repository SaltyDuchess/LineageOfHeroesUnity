using System.Collections.Generic;
using LineageOfHeroes.Spells;

namespace LineageOfHeroes.CharacterClasses
{
	public interface IClass
	{
			List<ISpell> classSpells { get; set; }
	}
}
