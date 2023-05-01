using LineageOfHeroes.ItemTypes.CapeType;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public abstract class Cape : EquipmentBase
	{
		[SerializeField] CapeData capeData;
		public CapeType capeType { get; set; }

		new protected virtual void Awake()
		{
			base.Awake();
			capeType = capeData.capeType;
		}
	}
}
