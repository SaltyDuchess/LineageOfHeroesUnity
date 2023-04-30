using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.RingType;

namespace LineageOfHeroes.ItemFactories.Ring
{
	public static class RingFactory
	{
    public static IItem CreateRing(RingType ringType)
    {
        switch (ringType)
        {
            case RingType.MagicalMuddling:
                return new MagicalMuddling();
						case RingType.PhysicalProtection:
                return new PhysicalProtection();
            default:
                throw new ArgumentException($"Invalid weapon type: {ringType}");
        }
    }
	}
}
