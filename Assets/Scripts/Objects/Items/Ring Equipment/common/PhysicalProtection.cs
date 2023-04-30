using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PhysicalProtection : Ring
	{
			private void Awake()
			{
					displayName = "Ring of Physical Protection";
					ringType = ItemTypes.RingType.RingType.PhysicalProtection;
					itemRarity = Rarity.Common;

					physDamageResist = RandomGenerator.Range(4f, 7f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases physical damage resistance by {physDamageResist} %";
			}
	}
}
