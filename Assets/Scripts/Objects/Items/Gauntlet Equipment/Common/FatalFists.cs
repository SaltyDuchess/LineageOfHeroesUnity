using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class FatalFists : Gauntlet
	{
		new private void Awake()
		{
			base.Awake();

			bonusCritChance = RandomGenerator.Range(5f, 15f);

			if (RandomGenerator.Range(1, 101) <= 50)
			{
				bonusCritDamage = RandomGenerator.Range(5f, 10f);
			}

			descriptionLong = $"{displayName}\nType - {type}\nIncreases critical damage probability by {bonusCritChance}%";

			if (bonusCritDamage > 0)
			{
				descriptionLong += $" and increases critical damage by {bonusCritDamage}%";
			}
		}
	}
}
