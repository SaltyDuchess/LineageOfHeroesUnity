using System;
using System.Collections.Generic;
using LineageOfHeroes.ConsumableTypes;
using LineageOfHeroes.ConsumableTypes.PotionType;
using UnityEngine;

public class ConsumableFactory : MonoBehaviour
{
	[SerializeField] private PotionFactory potionFactory;

	private Dictionary<ConsumableType, Func<string, ConsumableBase>> factoryMap;

	private void Awake()
	{
		factoryMap = new Dictionary<ConsumableType, Func<string, ConsumableBase>>
				{
						{ ConsumableType.Potion, formattedConsumableName => CreateConsumable<PotionType>(formattedConsumableName, potionFactory.CreatePotion) }
				};
	}

	public ConsumableBase CreateConsumable(ConsumableData consumableData)
	{
		if (factoryMap == null)
		{
			Debug.LogWarning("FactoryMap is null, initializing...");
			Awake(); // Ensure the dictionary is initialized
		}

		string formattedConsumableName = consumableData.displayName.Replace(" ", "");
		if (factoryMap.TryGetValue(consumableData.consumableType, out var factoryMethod))
		{
			return factoryMethod(formattedConsumableName);
		}
		throw new ArgumentException($"Invalid consumable type: {consumableData.consumableType}");
	}

	private ConsumableBase CreateConsumable<T>(string formattedConsumableName, Func<T, ConsumableBase> createMethod) where T : struct, Enum
	{
		if (Enum.TryParse(formattedConsumableName, out T consumableType))
		{
			return createMethod(consumableType);
		}
		throw new ArgumentException($"Expected a {typeof(T).Name} instead received {formattedConsumableName}");
	}
}
