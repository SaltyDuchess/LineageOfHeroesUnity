using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class MagiSpellBase : SpellBase
	{
		[SerializeField] MagiSpellData magiSpellData;
		public MagiSpellType magiType { get; set; }

		new protected virtual void Awake()
		{
			base.spellData = magiSpellData;
			base.Awake();
			magiType = magiSpellData.magiSpellType;
		}
	}
}