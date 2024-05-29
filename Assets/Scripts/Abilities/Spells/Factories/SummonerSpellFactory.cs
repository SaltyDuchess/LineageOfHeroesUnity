using System;
using LineageOfHeroes.Spells.SpellTypes;
using LineageOfHeroes.Spells.Summoner;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.Summoner
{
	public class SummonerSpellFactory : MonoBehaviour
	{
		[SerializeField] private MeaslyMiasma measlyMiasmaPrefab;
		[SerializeField] private PiedPiper piedPiperPrefab;
		public SummonerSpellBase CreateSummonerSpell(SummonerSpellType spellType)
		{
			switch (spellType)
			{
				case SummonerSpellType.MeaslyMiasma:
					return Instantiate(measlyMiasmaPrefab);
				case SummonerSpellType.PiedPiper:
					return Instantiate(piedPiperPrefab);
				default:
					throw new ArgumentException($"Invalid summoner spell type: {spellType}");
			}
		}
	}
}
