using System.Linq;
using UnityEngine;

public class SummonerShawl : Cape
{
    public SummonerShawl(Summoner summonerClass)
    {
        displayName = "Summoner Shawl";
        itemRarity = Rarity.Common;

        var eligibleSpells = summonerClass.classSpells
            .Where(spell => spell.levelRequirement >= 2 && spell.levelRequirement <= 3)
            .ToList();

        if (eligibleSpells.Count > 0)
        {
            int randomIndex = Random.Range(0, eligibleSpells.Count);
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
