using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.ChestType;

namespace LineageOfHeroes.ItemFactories.Chest
{
	public static class ChestFactory
	{
    public static IItem CreateChest(ChestType chestType)
    {
        switch (chestType)
        {
            case ChestType.HealthyHauberk:
                return new HealthyHauberk();
						case ChestType.StaminaStandard:
                return new StaminaStandard();
            default:
                throw new ArgumentException($"Invalid weapon type: {chestType}");
        }
    }
	}
}
