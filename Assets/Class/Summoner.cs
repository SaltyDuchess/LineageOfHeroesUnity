using System.Collections.Generic;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.Summoner;

namespace LineageOfHeroes.CharacterClasses
{
	public class Summoner : IClass
	{
			public List<ISpell> classSpells { get; set; }

			public Summoner()
			{
					classSpells = new List<ISpell>
					{
							new MeaslyMiasma(),
							new PiedPiper()
					};
			}
	}
}
