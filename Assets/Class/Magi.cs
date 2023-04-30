using System.Collections.Generic;

public class Magi : IClass
{
    public List<Spells> classSpells { get; set; }

    public Magi()
    {
        classSpells = new List<Spells>
        {
            new LivelyLightning(),
            new WeakWard(),
            new MagicMissile()
        };
    }
}
