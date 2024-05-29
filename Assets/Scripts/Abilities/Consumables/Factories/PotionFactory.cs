using LineageOfHeroes.ConsumableTypes.PotionType;
using UnityEngine;

public class PotionFactory : MonoBehaviour
{
    [SerializeField] private HealingHootch healingHootchPrefab;
		[SerializeField] private StaminaSpirit staminaSpiritPrefab;

		public PotionBase CreatePotion(PotionType potionType)
		{
			switch (potionType)
			{
				case PotionType.HealingHootch:
					return Instantiate(healingHootchPrefab);
				case PotionType.StaminaSpirit:
					return Instantiate(staminaSpiritPrefab);
				default:
					throw new System.ArgumentException($"Invalid potion type: {potionType}");
			}
		}
}
