using System;
using LineageOfHeroes.SpellFactory.Berzerker;
using LineageOfHeroes.SpellFactory.Magi;
using LineageOfHeroes.SpellFactory.Summoner;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory
{
	public class SpellFactory: MonoBehaviour
	{
		[SerializeField] public BerzerkerSpellFactory berzerkerSpellFactory;
		[SerializeField] public MagiSpellFactory magiSpellFactory;
		[SerializeField] public SummonerSpellFactory summonerSpellFactory;
		public SpellBase CreateSpell(SpellData spellData)
		{
			string formattedSpellName = spellData.displayName.Replace(" ", "");
			switch (spellData.spellType)
			{
				case SpellType.Berzerker:
					if (!Enum.TryParse(formattedSpellName, out BerzerkerSpellType berzerkerType)) throw new ArgumentException("Expected a BerzerkerSpellType instead received " + formattedSpellName);
					return berzerkerSpellFactory.CreateBerzerkerSpell(berzerkerType);
				case SpellType.Magi:
					if (!Enum.TryParse(formattedSpellName, out MagiSpellType magiType)) throw new ArgumentException("Expected a MagiSpellType instead received " + formattedSpellName);
					return magiSpellFactory.CreateMagiSpell(magiType);
				case SpellType.Summoner:
					if (!Enum.TryParse(formattedSpellName, out SummonerSpellType summonerType)) throw new ArgumentException("Expected a SummonerSpellType instead received " + formattedSpellName);
					return summonerSpellFactory.CreateSummonerSpell(summonerType);
				default:
					throw new ArgumentException($"Invalid spell type: {spellData.spellType}");
			}
		}
	}
}
