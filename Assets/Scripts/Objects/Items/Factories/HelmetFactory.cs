using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.HelmetType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Helmet
{
	public class HelmetFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.Helmet regenerationRemedyPrefab;
		[SerializeField] private LineageOfHeroes.Items.Helmet staminaSurgePrefab;
    public EquipmentBase CreateHelmet(HelmetType helmetType)
    {
        switch (helmetType)
        {
            case HelmetType.RegenerationRemedy:
                return Instantiate(regenerationRemedyPrefab);
						case HelmetType.StaminaSurge:
                return Instantiate(staminaSurgePrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {helmetType}");
        }
    }
	}
}
