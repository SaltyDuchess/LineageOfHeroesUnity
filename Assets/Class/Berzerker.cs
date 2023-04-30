using System.Collections.Generic;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.Berzerker;

namespace LineageOfHeroes.CharacterClasses
{
	public class Berzerker : IClass
	{
			public List<ISpell> classSpells { get; set; }

			public Berzerker()
			{
					classSpells = new List<ISpell>
					{
							new SanguinarySwap(),
							new WeepingWound(),
							new BeastlyBite(),
							new StunningStrike(),
							new FatalFinish(),
							new InstantImmolation()
					};
			}
	}
}
