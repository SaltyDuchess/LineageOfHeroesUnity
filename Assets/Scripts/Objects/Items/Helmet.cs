using UnityEngine;
using LineageOfHeroes.ItemTypes.HelmetType;

namespace LineageOfHeroes.Items
{
	public class Helmet : EquipmentBase
	{
		[SerializeField] HelmetData helmetData;
		public HelmetType helmetType { get; set; }

			new protected virtual void Awake()
			{
				base.equipmentData = helmetData;
				base.Awake();
				helmetType = helmetData.helmetType;
			}
	}
}
