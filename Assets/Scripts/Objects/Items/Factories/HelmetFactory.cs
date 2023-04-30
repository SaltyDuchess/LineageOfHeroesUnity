using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.HelmetType;

namespace LineageOfHeroes.ItemFactories.Helmet
{
	public static class HelmetFactory
	{
    public static IItem CreateHelmet(HelmetType helmetType)
    {
        switch (helmetType)
        {
            case HelmetType.RegenerationRemedy:
                return new RegenerationRemedy();
						case HelmetType.StaminaSurge:
                return new StaminaSurge();
            default:
                throw new ArgumentException($"Invalid weapon type: {helmetType}");
        }
    }
	}
}
