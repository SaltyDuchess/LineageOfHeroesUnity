using LineageOfHeroes.ConsumableTypes.PotionType;
using UnityEngine;

public class PotionBase : ConsumableBase
{
    [SerializeField] PotionData potionData;
		public ConsumableData ConsumableData => potionData;
		public PotionType PotionType => potionData.potionType;

		new protected virtual void Awake()
		{
			base.Awake();
		}
}
