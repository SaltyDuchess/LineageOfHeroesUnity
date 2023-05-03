using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.ShoulderType;

namespace LineageOfHeroes.ItemFactories.Shoulder
{
	public static class ShoulderFactory
	{
    public static IItem CreateShoulder(ShoulderType shoulderType)
    {
        switch (shoulderType)
        {
            case ShoulderType.Shoulder:
                return new LineageOfHeroes.Items.Shoulder();
            default:
                throw new ArgumentException($"Invalid weapon type: {shoulderType}");
        }
    }
	}
}
