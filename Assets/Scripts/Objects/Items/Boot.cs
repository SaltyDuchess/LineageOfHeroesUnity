using LineageOfHeroes.ItemTypes.BootType;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public abstract class Boot : EquipmentBase
	{
		[SerializeField] BootData bootData;
		public BootType bootType { get; set; }

		new protected virtual void Awake()
		{
			base.Awake();
			bootType = bootData.bootType;
		}
	}
}
