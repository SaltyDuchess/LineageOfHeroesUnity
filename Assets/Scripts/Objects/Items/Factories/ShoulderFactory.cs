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
            case ShoulderType.PauldronOfPertinacity:
                return new PauldronOfPertinacity();
						case ShoulderType.StrongShoulder:
                return new StrongShoulder();
            default:
                throw new ArgumentException($"Invalid weapon type: {shoulderType}");
        }
    }
	}
}
