using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PauldronOfPertinacity : Shoulder
	{
		new private void Awake()
		{
			base.Awake();

			bonusAbilityPower = RandomGenerator.Range(15f, 25f);

			descriptionLong = $"{displayName}\nType - {type}\nIncreases stamina by {bonusAbilityPower} %";
		}
	}
}
