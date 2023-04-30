using UnityEngine;

public class SneakySneakers : Boot
{
    public SneakySneakers()
    {
        displayName = "Sneaky Sneakers";
        itemRarity = Rarity.Common;
        bonusDodgeChance = Random.Range(2.5f, 5f);
        descriptionLong = $"{displayName}\nType - {type}\nIncreases dodge chance by {bonusDodgeChance}";
    }
}
