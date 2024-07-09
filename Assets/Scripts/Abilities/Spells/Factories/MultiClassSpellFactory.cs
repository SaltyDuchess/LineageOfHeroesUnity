using System;
using System.Collections.Generic;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.MultiClass
{
	public class MultiClassSpellFactory : MonoBehaviour
	{
		[SerializeField] private List<MultiClassSpellPrefabMapping> multiClassSpellPrefabs;

		private Dictionary<MultiClassSpellType, SpellBase> multiClassSpellPrefabDict;

		private void Awake()
		{
			InitializeDictionary();
		}

		private void InitializeDictionary()
		{
			multiClassSpellPrefabDict = new Dictionary<MultiClassSpellType, SpellBase>();
			foreach (var mapping in multiClassSpellPrefabs)
			{
				if (mapping.spellPrefab != null)
				{
					multiClassSpellPrefabDict[mapping.spellType] = mapping.spellPrefab;
				}
			}
		}

		public SpellBase CreateMultiClassSpell(MultiClassSpellType spellType)
		{
			if (multiClassSpellPrefabDict == null)
			{
				InitializeDictionary();
			}

			if (multiClassSpellPrefabDict.TryGetValue(spellType, out var prefab))
			{
				return Instantiate(prefab);
			}
			throw new ArgumentException($"Invalid magi spell type: {spellType}");
		}

		[Serializable]
		public struct MultiClassSpellPrefabMapping
		{
			public MultiClassSpellType spellType;
			public SpellBase spellPrefab;
		}
	}
}
