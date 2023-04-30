using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class StrongShoulder : Shoulder
	{
			private void Awake()
			{
					displayName = "Strong Shoulder";
					shoulderType = ItemTypes.ShoulderType.ShoulderType.StrongShoulder;
					itemRarity = Rarity.Common;

					bonusHp = RandomGenerator.Range(15f, 25f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases hp by {bonusHp} %";
			}
	}
}
