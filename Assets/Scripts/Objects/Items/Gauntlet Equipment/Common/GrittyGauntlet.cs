using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class GrittyGauntlet : Gauntlet
	{
		new private void Awake()
		{
			base.Awake();
			if (RandomGenerator.Range(1, 101) <= 50)
			{
				bonusHp = RandomGenerator.Range(15f, 26f);
			}
			else
			{
				bonusHp = RandomGenerator.Range(10f, 16f);
				bonusHpRegen = RandomGenerator.Range(0.5f, 1.1f);
			}

			descriptionLong = $"{displayName}\nType - {type}\nIncreases HP by {bonusHp}";

			if (bonusHpRegen > 0)
			{
				descriptionLong += $" and increases HP regen by {bonusHpRegen}";
			}
		}
	}
}
