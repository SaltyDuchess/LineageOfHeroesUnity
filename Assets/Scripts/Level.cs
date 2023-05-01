public interface ILevel
{
    public int currentLevel { get; set; }
    public int currentXP { get; set; }
    public int XPToNextLevel { get; set; }
    public int abilityPoints { get; set; }

    // Add common functionality for leveling up and other level-related features here.
}