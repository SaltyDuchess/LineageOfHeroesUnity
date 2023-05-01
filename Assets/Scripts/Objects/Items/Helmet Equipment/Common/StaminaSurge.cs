using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class StaminaSurge : Helmet
	{
		new private void Awake()
		{
			base.Awake();

			bonusAbilityPowerRegen = RandomGenerator.Range(1f, 3.1f);

			descriptionLong = $"{displayName}\nType - {type}\nIncreases ability power regen by {bonusAbilityPowerRegen}";
		}
	}
}
