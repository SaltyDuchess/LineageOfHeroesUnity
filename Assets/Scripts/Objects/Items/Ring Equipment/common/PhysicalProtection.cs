using System.Collections;
using System.Collections.Generic;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PhysicalProtection : Ring
	{
		new private void Awake()
		{
			base.Awake();

			physDamageResist = RandomGenerator.Range(4f, 7f);

			descriptionLong = $"{displayName}\nType - {type}\nIncreases physical damage resistance by {physDamageResist} %";
		}
	}
}
