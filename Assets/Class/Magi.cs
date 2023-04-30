using System.Collections.Generic;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.Magi;

namespace LineageOfHeroes.CharacterClasses
{
	public class Magi : IClass
	{
			public List<ISpell> classSpells { get; set; }

			public Magi()
			{
					classSpells = new List<ISpell>
					{
							new LivelyLightning(),
							new WeakWard(),
							new MagicMissile()
					};
			}
	}
}
