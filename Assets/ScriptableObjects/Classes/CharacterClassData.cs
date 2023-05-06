using UnityEngine;

[CreateAssetMenu(fileName = "CharacterClass", menuName = "CharacterClass")]
public class CharacterClassData : ScriptableObject
{
	public ClassSpellLibrary classSpellLibrary;
	public string className;
}
