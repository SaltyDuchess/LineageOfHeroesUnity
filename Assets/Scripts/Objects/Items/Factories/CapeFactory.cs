using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.CapeType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Cape
{
	public class CapeFactory : MonoBehaviour
	{
		[SerializeField] private LineageOfHeroes.Items.MagiMantle magiMantlePrefab;
		[SerializeField] private LineageOfHeroes.Items.SummonerShawl summonerShawlPrefab;
    public EquipmentBase CreateCape(CapeType capeType)
    {
        switch (capeType)
        {
            case CapeType.MagiMantle:
                return Instantiate(magiMantlePrefab);
						case CapeType.SummonerShawl:
                return Instantiate(summonerShawlPrefab);
            default:
                throw new ArgumentException($"Invalid weapon type: {capeType}");
        }
    }
	}
}
