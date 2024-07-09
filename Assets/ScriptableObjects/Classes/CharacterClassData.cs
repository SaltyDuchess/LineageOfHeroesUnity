using UnityEngine;

[CreateAssetMenu(fileName = "CharacterClass", menuName = "CharacterClass")]
public class CharacterClassData : ScriptableObject
{
	public ClassSpellLibrary classSpellLibrary;
	public ClassSpellLibrary multiClassSpellLibrary;
	public ClassPermanentUpgradeLibrary classPermanentUpgradeLibrary;
	public string className;
}
