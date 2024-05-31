using System;
using System.Collections.Generic;
using LineageOfHeroes.Spells.SpellTypes;
using LineageOfHeroes.Spells.Summoner;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.Summoner
{
	public class SummonerSpellFactory : MonoBehaviour
	{
		[SerializeField] private List<SummonerSpellPrefabMapping> summonerSpellPrefabs;

		private Dictionary<SummonerSpellType, SummonerSpellBase> summonerSpellPrefabDict;

		private void Awake()
		{
			InitializeDictionary();
		}

		private void InitializeDictionary()
		{
			summonerSpellPrefabDict = new Dictionary<SummonerSpellType, SummonerSpellBase>();
			foreach (var mapping in summonerSpellPrefabs)
			{
				if (mapping.spellPrefab != null)
				{
					summonerSpellPrefabDict[mapping.spellType] = mapping.spellPrefab;
				}
			}
		}

		public SummonerSpellBase CreateSummonerSpell(SummonerSpellType spellType)
		{
			if (summonerSpellPrefabDict == null)
			{
				InitializeDictionary();
			}

			if (summonerSpellPrefabDict.TryGetValue(spellType, out var prefab))
			{
				return Instantiate(prefab);
			}
			throw new ArgumentException($"Invalid summoner spell type: {spellType}");
		}

		[Serializable]
		public struct SummonerSpellPrefabMapping
		{
			public SummonerSpellType spellType;
			public SummonerSpellBase spellPrefab;
		}
	}
}
