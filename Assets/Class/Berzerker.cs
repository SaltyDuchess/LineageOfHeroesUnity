using System.Collections.Generic;

public class Berzerker : IClass
{
    public List<Spells> classSpells { get; set; }

    public Berzerker()
    {
        classSpells = new List<Spells>
        {
            new SanguinarySwap(),
            new WeepingWound(),
            new BeastlyBite(),
            new StunningStrike(),
            new FatalFinish(),
            new InstantImmolation()
        };
    }
}
