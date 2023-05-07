using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

public class SpellData : ScriptableObject
{
	public SpellType spellType;
	public string spellName;
	public Sprite uiElement;
	public int levelRequirement;
	public float abilityPowerCost;
	public int cooldown;
	public bool instantCast;
	public float physDamageModifier;
	public float magicDamageModifier;
	public float DOT;
	public int DOTTurns;
	public int stunTurns;
}
