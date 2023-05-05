public interface IMob : ICreature
{
    bool isPlayer { get; }
    string displayName { get; set; }
    string mobDescription { get; set; }
}
