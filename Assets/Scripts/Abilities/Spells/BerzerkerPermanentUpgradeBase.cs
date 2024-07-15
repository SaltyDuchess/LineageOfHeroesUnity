using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class BerzerkerPermanentUpgradeBase : PermanentUpgradeBase
	{
		[SerializeField] BerzerkerPermanentUpgradeData berzerkerPermanentUpgradeData;
		public BerzerkerSpellType berzerkerSpellType { get; set; }

		new protected virtual void Awake()
		{
			base.spellData = berzerkerPermanentUpgradeData;
			base.Awake();
			berzerkerSpellType = berzerkerPermanentUpgradeData.berzerkerSpellType;
		}
	}
}