using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class SneakySneakers : Boot
	{
			public SneakySneakers()
			{
					displayName = "Sneaky Sneakers";
					itemRarity = Rarity.Common;
					bootType = ItemTypes.BootType.BootType.SneakySneakers;
					bonusDodgeChance = RandomGenerator.Range(2.5f, 5f);
					descriptionLong = $"{displayName}\nType - {type}\nIncreases dodge chance by {bonusDodgeChance}";
			}
	}
}
