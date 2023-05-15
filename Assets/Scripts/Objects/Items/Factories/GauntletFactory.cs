using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.GauntletType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Gauntlet
{
	public class GauntletFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.GrittyGauntlet grittyGauntletPrefab;
		[SerializeField] private LineageOfHeroes.Items.FatalFists fatalFistsPrefab;
    public EquipmentBase CreateGauntlet(GauntletType gauntletType)
    {
        switch (gauntletType)
        {
            case GauntletType.FatalFists:
                return Instantiate(fatalFistsPrefab);
						case GauntletType.GrittyGauntlet:
                return Instantiate(grittyGauntletPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {gauntletType}");
        }
    }
	}
}
