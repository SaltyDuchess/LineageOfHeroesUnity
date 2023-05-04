using UnityEngine;

[CreateAssetMenu(fileName = "NewCreatureData", menuName = "ScriptableObjects/CreatureData")]
public class CreatureData : ScriptableObject
{
	public Sprite uiElement;
	public CreatureStats stats = new CreatureStats();
	public string displayName;
	public string mobDescription;
}
