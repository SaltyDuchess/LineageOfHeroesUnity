using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.ShoulderType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Shoulder
{
	public class ShoulderFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.Shoulder pauldronOfPertinacityPrefab;
		[SerializeField] private LineageOfHeroes.Items.Shoulder strongShoulderPrefab;
    public EquipmentBase CreateShoulder(ShoulderType shoulderType)
    {
        switch (shoulderType)
        {
            case ShoulderType.PauldronOfPertinacity:
                return Instantiate(pauldronOfPertinacityPrefab);
						case ShoulderType.StrongShoulder:
                return Instantiate(strongShoulderPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {shoulderType}");
        }
    }
	}
}
