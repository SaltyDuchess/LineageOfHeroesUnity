using System.Linq;
using UnityEngine;

public class MagiMantle : Cape
{
    public MagiMantle(Magi magiClass)
    {
        displayName = "Magi Mantle";
        itemRarity = Rarity.Common;

        var eligibleSpells = magiClass.classSpells
            .Where(spell => spell.levelRequirement >= 2 && spell.levelRequirement <= 3)
            .ToList();

        if (eligibleSpells.Count > 0)
        {
            int randomIndex = Random.Range(0, eligibleSpells.Count);
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
