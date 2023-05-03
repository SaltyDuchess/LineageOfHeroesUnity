using LineageOfHeroes.ItemTypes.BootType;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class Boot : EquipmentBase
	{
		[SerializeField] BootData bootData;
		public BootType bootType { get; set; }

		new protected virtual void Awake()
		{
			base.equipmentData = bootData;
			base.Awake();
			bootType = bootData.bootType;
		}
	}
}
