using System.Collections.Generic;

public class Summoner : IClass
{
    public List<Spells> classSpells { get; set; }

    public Summoner()
    {
        classSpells = new List<Spells>
        {
            new MeaslyMiasma(),
            new PiedPiper()
        };
    }
}
