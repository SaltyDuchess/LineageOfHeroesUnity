using System.Linq;
using LineageOfHeroes.CharacterClasses;
using LineageOfHeroes.Randomization;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class SummonerShawl : Cape
	{
		[SerializeField] private ClassSpellLibrary summonerClass;
			new private void Awake()
			{
					displayName = "Summoner Shawl";
					capeType = ItemTypes.CapeType.CapeType.SummonerShawl;
					itemRarity = Rarity.Common;

					var eligibleSpells = summonerClass.classSpells
							.Where(spell => spell.levelRequirement >= 2 && spell.levelRequirement <= 3)
							.ToList();

					if (eligibleSpells.Count > 0)
					{
							int randomIndex = RandomGenerator.Range(0, eligibleSpells.Count);
							boundAbility = eligibleSpells[randomIndex];
					}
					else
					{
							Debug.LogWarning("No eligible spells found for Summoner Shawl");
							boundAbility = null;
					}

					descriptionLong = $"{displayName}\nType - {type}\nAdds {boundAbility.displayName} to your available abilities";
			}
	}
}
