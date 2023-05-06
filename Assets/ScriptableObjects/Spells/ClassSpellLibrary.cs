using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassSpellLibrary", menuName = "ClassSpellLibrary", order = 1)]
public class ClassSpellLibrary : ScriptableObject
{
    public List<SpellBase> classSpells;

		public ClassSpellLibrary(){}
}
