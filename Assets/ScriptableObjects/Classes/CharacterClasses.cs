using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
    public abstract class CharacterClass : ScriptableObject, IClass
    {
        public List<SpellBase> classSpells { get; set;}
        public abstract void ModifyPlayerStats(Player player);
    }
}
