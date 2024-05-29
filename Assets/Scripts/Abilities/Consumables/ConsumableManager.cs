using UnityEngine;
using System.Collections.Generic;

public class ConsumableManager : MonoBehaviour
{
    [SerializeField] private List<ConsumableData> allConsumables;

    private void Awake()
    {
        ResetConsumableData();
    }

    public void ResetConsumableData()
    {
        foreach (var consumable in allConsumables)
        {
            consumable.quantity = 0;
        }
    }
}
