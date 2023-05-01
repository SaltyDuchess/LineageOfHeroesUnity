using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestData", menuName = "Equipment/ChestData", order = 4)]
public class ChestData : EquipmentData
{
	public LineageOfHeroes.ItemTypes.ChestType.ChestType chestType;
}
