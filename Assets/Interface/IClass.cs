using System.Collections.Generic;
using LineageOfHeroes.Spells;

namespace LineageOfHeroes.CharacterClasses
{
    public interface IClass
    {
        List<SpellBase> classSpells { get; set; }
    }
}
