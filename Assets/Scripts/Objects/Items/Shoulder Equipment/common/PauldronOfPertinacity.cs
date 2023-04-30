using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PauldronOfPertinacity : Shoulder
	{
			private void Awake()
			{
					displayName = "Pauldron of Pertinacity";
					shoulderType = ItemTypes.ShoulderType.ShoulderType.PauldronOfPertinacity;
					itemRarity = Rarity.Common;

					bonusAbilityPower = RandomGenerator.Range(15f, 25f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases stamina by {bonusAbilityPower} %";
			}
	}
}
