using LineageOfHeroes.Randomization;

namespace LineageOfHeroes.Items
{
	public class HealthyHauberk : Chest
	{
		new private void Awake()
		{
			base.Awake();

			int randomValue = RandomGenerator.Range(1, 101);
			// equipment will have hp regen, reduce bonus hp via loot divergance value
			if (randomValue >= 50)
			{
				bonusHp = bonusHp / equipmentData.lootDivergance.GetRandomValue();
			}
			// equipment will not have hp regen
			else
			{
				bonusHpRegen = 0;
			}

			descriptionLong = displayName
					+ "\nType - " + type
					+ "\nIncreases HP by " + bonusHp.ToString();

			if (bonusHpRegen > 0)
			{
				descriptionLong += " and increases HP regen by " + bonusHpRegen.ToString();
			}
		}
	}
}
