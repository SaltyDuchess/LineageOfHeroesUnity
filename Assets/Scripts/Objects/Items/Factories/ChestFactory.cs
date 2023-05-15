using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.ChestType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Chest
{
	public class ChestFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.HealthyHauberk healthyHauberkPrefab;
		[SerializeField] private LineageOfHeroes.Items.StaminaStandard staminaStandardPrefab;
    public EquipmentBase CreateChest(ChestType chestType)
    {
        switch (chestType)
        {
            case ChestType.HealthyHauberk:
                return Instantiate(healthyHauberkPrefab);
						case ChestType.StaminaStandard:
                return Instantiate(staminaStandardPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {chestType}");
        }
    }
	}
}
