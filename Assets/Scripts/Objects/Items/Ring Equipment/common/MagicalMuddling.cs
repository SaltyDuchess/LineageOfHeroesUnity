using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class MagicalMuddling : Ring
	{
			private void Awake()
			{
					displayName = "Ring of Magical Muddling";
					ringType = ItemTypes.RingType.RingType.MagicalMuddling;
					itemRarity = Rarity.Common;

					magicDamageResist = RandomGenerator.Range(4f, 7f);

					descriptionLong = $"{displayName}\nType - {type}\nIncreases magical damage resistance by {magicDamageResist} %";
			}
	}
}
