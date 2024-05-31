using System;
using System.Collections.Generic;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.Magi;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.Magi
{
	public class MagiSpellFactory : MonoBehaviour
	{
		[SerializeField] private List<MagiSpellPrefabMapping> magiSpellPrefabs;

		private Dictionary<MagiSpellType, MagiSpellBase> magiSpellPrefabDict;

		private void Awake()
		{
			InitializeDictionary();
		}

		private void InitializeDictionary()
		{
			magiSpellPrefabDict = new Dictionary<MagiSpellType, MagiSpellBase>();
			foreach (var mapping in magiSpellPrefabs)
			{
				if (mapping.spellPrefab != null)
				{
					magiSpellPrefabDict[mapping.spellType] = mapping.spellPrefab;
				}
			}
		}

		public MagiSpellBase CreateMagiSpell(MagiSpellType spellType)
		{
			if (magiSpellPrefabDict == null)
			{
				InitializeDictionary();
			}

			if (magiSpellPrefabDict.TryGetValue(spellType, out var prefab))
			{
				return Instantiate(prefab);
			}
			throw new ArgumentException($"Invalid magi spell type: {spellType}");
		}

		[Serializable]
		public struct MagiSpellPrefabMapping
		{
			public MagiSpellType spellType;
			public MagiSpellBase spellPrefab;
		}
	}
}
