using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.BootType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Boot
{
	public class BootFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.Boot sneakySneakersPrefab;
    public EquipmentBase CreateBoot(BootType bootType)
    {
        switch (bootType)
        {
            case BootType.SneakySneakers:
                return Instantiate(sneakySneakersPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {bootType}");
        }
    }
	}
}
