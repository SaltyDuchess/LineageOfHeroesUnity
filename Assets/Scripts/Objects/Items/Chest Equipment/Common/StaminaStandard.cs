using UnityEngine;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;

namespace LineageOfHeroes.Items
{
	public class StaminaStandard : Chest
	{
		new private void Awake()
		{
			base.Awake();

			int randomValue = RandomGenerator.Range(1, 101);
			if (randomValue <= 50)
			{
				bonusAbilityPower = RandomGenerator.Range(30f, 46f);
			}
			else
			{
				bonusAbilityPower = RandomGenerator.Range(15f, 26f);
				bonusAbilityPowerRegen = RandomGenerator.Range(1f, 4f);
			}

			descriptionLong = displayName
					+ "\nType - " + type
					+ "\nIncreases Stamina by " + bonusAbilityPower.ToString();

			if (bonusAbilityPowerRegen > 0)
			{
				descriptionLong += " and increases Stamina regen by " + bonusAbilityPowerRegen.ToString();
			}
		}
	}
}
