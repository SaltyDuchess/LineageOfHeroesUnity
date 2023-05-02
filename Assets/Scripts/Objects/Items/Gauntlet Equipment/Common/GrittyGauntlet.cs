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
				bonusHpRegen = 0;
			}
			else
			{
				bonusHp = bonusHp / equipmentData.lootDivergance.GetRandomValue();
			}

			descriptionLong = $"{displayName}\nType - {type}\nIncreases HP by {bonusHp}";

			if (bonusHpRegen > 0)
			{
				descriptionLong += $" and increases HP regen by {bonusHpRegen}";
			}
		}
	}
}
