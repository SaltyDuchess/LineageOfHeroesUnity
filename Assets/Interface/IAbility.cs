public interface IAbility : IBaseGameObject
{
    public int cooldown { get; set; }
		public int currentCooldown { get; set; }
    public int levelRequirement { get; set; }
    public bool instantCast { get; set; }
    public float abilityPowerCost { get; set; }
    public bool isCastable { get; set; }
    public Creature targetedEnemy { get; set; }
		public bool isSustainedSpell { get; set; }

		public abstract bool IsCastable(Creature castingCreature = null);
		public abstract void ExecuteAbility(Creature castingCreature = null, Creature defender = null);
}