using LineageOfHeroes.Spells.SpellTypes;

namespace LineageOfHeroes.Spells
{
	public interface ISpell : IAbility
	{
		public SpellType type { get; set; }
		public float physDamageModifier { get; set; }
		public float magicDamageModifier { get; set; }
		public float DOT { get; set; }
		public int DOTTurns { get; set; }
		public int stunTurns { get; set; }
		public CalcCritAndDamage calcCritAndDamage { get; set; }

		// Add spell-specific functionality here.
	}
}
