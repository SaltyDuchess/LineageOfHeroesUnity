using LineageOfHeroes.ItemTypes;
using LineageOfHeroes.ItemTypes.CapeType;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class Cape : EquipmentBase
	{
		[SerializeField] CapeData capeData;
		public CapeType capeType { get; set; }

		new protected virtual void Awake()
		{
			base.equipmentData = capeData;
			type = ItemType.Cape;
			capeType = capeData.capeType;
			base.Awake();
		}
	}
}
