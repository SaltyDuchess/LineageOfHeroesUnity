using System;
using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.ConsumableTypes;
using LineageOfHeroes.ConsumableTypes.PotionType;
using UnityEngine;

public class ConsumableFactory : MonoBehaviour
{
  [SerializeField] private PotionFactory potionFactory;

	public ConsumableBase CreateConsumable(ConsumableData consumableData)
	{
		string formattedConsumableName = consumableData.displayName.Replace(" ", "");
		switch (consumableData.consumableType)
		{
			case ConsumableType.Potion:
				if(!Enum.TryParse(formattedConsumableName, out PotionType potionType))
					throw new System.ArgumentException($"Invalid potion type: {formattedConsumableName}");
				return potionFactory.CreatePotion(potionType);
			default:
				throw new System.ArgumentException($"Invalid consumable type: {consumableData.consumableType}");
		}
	}
}
