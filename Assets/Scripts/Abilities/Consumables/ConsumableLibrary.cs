using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConsumableLibrary : MonoBehaviour
{
    [SerializeField] private List<ConsumableData> allConsumables; // List of all available consumables in the game

    public ConsumableData GetConsumableByName(string consumableName)
    {
      return allConsumables.FirstOrDefault(consumable => consumable.displayName == consumableName);
    }
}
