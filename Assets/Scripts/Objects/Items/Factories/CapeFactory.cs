using System;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.CapeType;

namespace LineageOfHeroes.ItemFactories.Cape
{
	public static class CapeFactory
	{
    public static IItem CreateCape(CapeType capeType)
    {
        switch (capeType)
        {
            case CapeType.MagiMantle:
                return new MagiMantle();
						case CapeType.SummonerShawl:
                return new SummonerShawl();
            default:
                throw new ArgumentException($"Invalid weapon type: {capeType}");
        }
    }
	}
}
