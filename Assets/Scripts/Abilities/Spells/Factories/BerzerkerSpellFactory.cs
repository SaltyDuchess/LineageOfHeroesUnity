using System;
using System.Collections.Generic;
using LineageOfHeroes.Spells.Berzerker;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.Berzerker
{
	public class BerzerkerSpellFactory : MonoBehaviour
	{
		[SerializeField] private List<BerzerkerSpellPrefabMapping> berzerkerSpellPrefabs;

		private Dictionary<BerzerkerSpellType, BerzerkerSpellBase> berzerkerSpellPrefabDict;

		private void Awake()
		{
			InitializeDictionary();
		}

		private void InitializeDictionary()
		{
			berzerkerSpellPrefabDict = new Dictionary<BerzerkerSpellType, BerzerkerSpellBase>();
			foreach (var mapping in berzerkerSpellPrefabs)
			{
				if (mapping.spellPrefab != null)
				{
					berzerkerSpellPrefabDict[mapping.spellType] = mapping.spellPrefab;
				}
			}
		}

		public BerzerkerSpellBase CreateBerzerkerSpell(BerzerkerSpellType spellType)
		{
			if (berzerkerSpellPrefabDict == null)
			{
				InitializeDictionary();
			}

			if (berzerkerSpellPrefabDict.TryGetValue(spellType, out var prefab))
			{
				return Instantiate(prefab);
			}
			throw new ArgumentException($"Invalid berzerker spell type: {spellType}");
		}

		[Serializable]
		public struct BerzerkerSpellPrefabMapping
		{
			public BerzerkerSpellType spellType;
			public BerzerkerSpellBase spellPrefab;
		}
	}
}
