using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class BerzerkerSpellBase : SpellBase
	{
		[SerializeField] BerzerkerSpellData berzerkerSpellData;
		public BerzerkerSpellType berzerkerSpellType { get; set; }

		new protected virtual void Awake()
		{
			base.spellData = berzerkerSpellData;
			base.Awake();
			berzerkerSpellType = berzerkerSpellData.berzerkerSpellType;
		}
	}
}