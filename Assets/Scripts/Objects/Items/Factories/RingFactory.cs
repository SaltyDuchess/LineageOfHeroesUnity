using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.RingType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Ring
{
	public class RingFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.Ring magicalMuddlingPrefab;
		[SerializeField] private LineageOfHeroes.Items.Ring physicalProtectionPrefab;
    public EquipmentBase CreateRing(RingType ringType)
    {
        switch (ringType)
        {
            case RingType.MagicalMuddling:
                return Instantiate(magicalMuddlingPrefab);
						case RingType.PhysicalProtection:
                return Instantiate(physicalProtectionPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {ringType}");
        }
    }
	}
}
