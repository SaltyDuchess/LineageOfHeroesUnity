using System.Collections.Generic;
using LineageOfHeroes.Spells;
using UnityEngine;
using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.GauntletType;

namespace LineageOfHeroes.Items
{
	public abstract class Gauntlet : EquipmentBase
	{
		[SerializeField] GauntletData gauntletData;
			public GauntletType gauntletType { get; set; }

			new protected virtual void Awake()
			{
				base.Awake();
				gauntletType = gauntletData.gauntletType;
			}
	}
}
