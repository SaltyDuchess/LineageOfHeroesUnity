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
            case BootType.Boot:
                return new LineageOfHeroes.Items.Boot();
            default:
                throw new ArgumentException($"Invalid weapon type: {bootType}");
        }
    }
	}
}
