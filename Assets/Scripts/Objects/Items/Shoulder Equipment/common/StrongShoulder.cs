using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class StrongShoulder : Shoulder
	{
			new private void Awake()
			{
				base.Awake();
				bonusHp = RandomGenerator.Range(15f, 25f);

				descriptionLong = $"{displayName}\nType - {type}\nIncreases hp by {bonusHp} %";
			}
	}
}
