using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassSpellLibrary", menuName = "ClassSpellLibrary", order = 1)]
public class ClassSpellLibrary : ScriptableObject
{
    public List<SpellData> classSpells;

		public ClassSpellLibrary(){}
}
