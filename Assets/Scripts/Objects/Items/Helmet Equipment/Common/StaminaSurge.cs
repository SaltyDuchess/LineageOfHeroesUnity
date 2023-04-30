using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class StaminaSurge : Helmet
	{
			private void Awake()
			{
					displayName = "Helmet of Stamina Surge";
					helmetType = ItemTypes.HelmetType.HelmetType.StaminaSurge;
					itemRarity = Rarity.Common;

					bonusAbilityPowerRegen = RandomGenerator.Range(1f, 3.1f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases ability power regen by {bonusAbilityPowerRegen}";
			}
	}
}
