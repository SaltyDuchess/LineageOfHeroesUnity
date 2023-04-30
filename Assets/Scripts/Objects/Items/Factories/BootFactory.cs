using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.BootType;

namespace LineageOfHeroes.ItemFactories.Boot
{
	public static class BootFactory
	{
    public static IItem CreateBoot(BootType bootType)
    {
        switch (bootType)
        {
            case BootType.SneakySneakers:
                return new SneakySneakers();
            default:
                throw new ArgumentException($"Invalid weapon type: {bootType}");
        }
    }
	}
}
