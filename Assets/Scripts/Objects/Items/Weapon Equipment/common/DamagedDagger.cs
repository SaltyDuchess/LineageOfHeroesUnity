using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class DamagedDagger : Weapon
	{
		new private void Awake()
		{
			base.Awake();
			critChanceModifier = 20f;
			critDamageMultiplier = 0.15f;

			descriptionLong = $"{displayName}\nType - {type}\nIncreases damage by {damageRange.minValue} - {damageRange.maxValue}," +
												$" increases crit chance by {critChanceModifier}% and increases critical damage by {critDamageMultiplier * 100}%";
		}
	}
}
