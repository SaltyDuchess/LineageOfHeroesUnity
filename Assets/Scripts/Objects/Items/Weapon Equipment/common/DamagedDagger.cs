using UnityEngine;
using System.Collections.Generic;

namespace LineageOfHeroes.Items
{
	public class DamagedDagger : Weapon
	{
			public Sprite uiElementSprite;

			private void Awake()
			{
					displayName = "Damaged Dagger";
					weaponType = ItemTypes.WeaponType.WeaponType.DamagedDagger;
					critChanceModifier = 20f;
					critDamageMultiplier = 0.15f;
					damageRange = new List<float> { 25.2f, 29.4f };

					descriptionLong = $"{displayName}\nType - {type}\nIncreases damage by {damageRange[0]} - {damageRange[1]}," +
														$" increases crit chance by {critChanceModifier}% and increases critical damage by {critDamageMultiplier * 100}%";
			}
	}
}
