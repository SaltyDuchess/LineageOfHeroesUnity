using System;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.Magi;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.Magi
{
	public class MagiSpellFactory : MonoBehaviour
	{
		[SerializeField] private LivelyLightning livelyLightningPrefab;
		[SerializeField] private MagicMissile magicMissilePrefab;
		[SerializeField] private WeakWard weakWardPrefab;
		public MagiSpellBase CreateMagiSpell(MagiSpellType spellType)
		{
			switch (spellType)
			{
				case MagiSpellType.LivelyLightning:
					return Instantiate(livelyLightningPrefab);
				case MagiSpellType.MagicMissile:
					return Instantiate(magicMissilePrefab);
				case MagiSpellType.WeakWard:
					return Instantiate(weakWardPrefab);
				default:
					throw new ArgumentException($"Invalid magi spell type: {spellType}");
			}
		}
	}
}
