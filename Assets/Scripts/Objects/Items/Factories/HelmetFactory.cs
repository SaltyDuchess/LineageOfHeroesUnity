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
            case HelmetType.Helmet:
                return new LineageOfHeroes.Items.Helmet();
            default:
                throw new ArgumentException($"Invalid weapon type: {helmetType}");
        }
    }
	}
}
