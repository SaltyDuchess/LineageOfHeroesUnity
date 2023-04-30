using System.Linq;
using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class MagiMantle : Cape
	{
			[SerializeField] private Magi magiClass;
			public void Awake()
			{
					displayName = "Magi Mantle";
					capeType = ItemTypes.CapeType.CapeType.MagiMantle;
					itemRarity = Rarity.Common;

					var eligibleSpells = magiClass.classSpells
							.Where(spell => spell.levelRequirement >= 2 && spell.levelRequirement <= 3)
							.ToList();

					if (eligibleSpells.Count > 0)
					{
							int randomIndex = RandomGenerator.Range(0, eligibleSpells.Count);
							boundAbility = eligibleSpells[randomIndex];
					}
					else
					{
							Debug.LogWarning("No eligible spells found for Magi Mantle");
							boundAbility = null;
					}

					descriptionLong = $"{displayName}\nType - {type}\nAdds {boundAbility.displayName} to your available abilities";
			}
	}
}
