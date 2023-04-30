using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class SmallSword : Weapon
	{
			public Sprite uiElementSprite;

			private void Awake()
			{
					displayName = "Small Sword";
					weaponType = ItemTypes.WeaponType.WeaponType.SmallSword;
					damageRange = new List<float> { 32.6f, 38.2f };

					descriptionLong = $"{displayName}\nType - {type}\nIncreases damage by {damageRange[0]} - {damageRange[1]},";
			}
	}
}
