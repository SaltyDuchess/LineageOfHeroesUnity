using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class HealthyHauberk : Chest
	{
		new private void Awake()
		{
			base.Awake();

			int randomValue = RandomGenerator.Range(1, 101);
			if (randomValue <= 50)
			{
				bonusHp = RandomGenerator.Range(25f, 51f);
			}
			else
			{
				bonusHp = RandomGenerator.Range(10f, 16f);
				bonusHpRegen = RandomGenerator.Range(0.5f, 2.1f);
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
