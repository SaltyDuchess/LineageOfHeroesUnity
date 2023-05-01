using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Equipment/CapeData", order = 3)]
public class CapeData : EquipmentData
{
	public LineageOfHeroes.ItemTypes.CapeType.CapeType capeType;
	public List<ISpell> eligibleSpells;
}