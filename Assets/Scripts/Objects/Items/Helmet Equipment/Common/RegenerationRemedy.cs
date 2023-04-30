using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class RegenerationRemedy : Helmet
	{
			private void Awake()
			{
					displayName = "Helmet of Regeneration Remedy";
					helmetType = ItemTypes.HelmetType.HelmetType.RegenerationRemedy;
					itemRarity = Rarity.Common;

					bonusHpRegen = RandomGenerator.Range(.3f, 1.2f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases hp regen regen by {bonusHpRegen}";
			}
	}
}
