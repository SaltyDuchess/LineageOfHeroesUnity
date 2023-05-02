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
				bonusAbilityPowerRegen = 0;
			}
			else
			{
				bonusAbilityPower = bonusAbilityPower / equipmentData.lootDivergance.GetRandomValue();
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
