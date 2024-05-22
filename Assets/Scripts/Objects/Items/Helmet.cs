using UnityEngine;
using LineageOfHeroes.ItemTypes.HelmetType;
using LineageOfHeroes.ItemTypes;

namespace LineageOfHeroes.Items
{
	public class Helmet : EquipmentBase
	{
		[SerializeField] HelmetData helmetData;
		public HelmetType helmetType { get; set; }

			new protected virtual void Awake()
			{
				base.equipmentData = helmetData;
				type = ItemType.Helmet;
				helmetType = helmetData.helmetType;
				base.Awake();
			}
	}
}
