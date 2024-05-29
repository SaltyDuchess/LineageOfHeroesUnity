using LineageOfHeroes.ConsumableTypes.PotionType;
using LineageOfHeroes.Items;
using UnityEngine;

public class PotionFactory : MonoBehaviour
{
    [SerializeField] private HealingHootch healingHootchPrefab;

		public PotionBase CreatePotion(PotionType potionType)
		{
			switch (potionType)
			{
				case PotionType.HealingHootch:
					return Instantiate(healingHootchPrefab);
				default:
					throw new System.ArgumentException($"Invalid potion type: {potionType}");
			}
		}
}
