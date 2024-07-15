using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells
{
	public class PermanentUpgradeBase : SpellBase
	{
		[SerializeField] public PermanentUpgradeData permanentUpgradeData;
		public SpellType spellType { get; set; }

		new protected virtual void Awake()
		{
			base.spellData = permanentUpgradeData;
			base.Awake();
			spellType = permanentUpgradeData.spellType;
		}
	}
}