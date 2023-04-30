using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.GauntletType;

namespace LineageOfHeroes.ItemFactories.Gauntlet
{
	public static class GauntletFactory
	{
    public static IItem CreateGauntlet(GauntletType gauntletType)
    {
        switch (gauntletType)
        {
            case GauntletType.FatalFists:
                return new FatalFists();
						case GauntletType.GrittyGauntlet:
                return new GrittyGauntlet();
            default:
                throw new ArgumentException($"Invalid weapon type: {gauntletType}");
        }
    }
	}
}
