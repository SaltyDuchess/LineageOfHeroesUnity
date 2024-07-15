using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	[CreateAssetMenu(fileName = "BerzerkerPermanentUpgradeData", menuName = "Spells/BerzerkerPermanentUpgradeData", order = 1)]
	public class BerzerkerPermanentUpgradeData : PermanentUpgradeData
	{
		public BerzerkerSpellType berzerkerSpellType;
	}
}