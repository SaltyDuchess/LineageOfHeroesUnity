using System;
using System.Collections.Generic;
using LineageOfHeroes.SpellFactory.Berzerker;
using LineageOfHeroes.SpellFactory.Magi;
using LineageOfHeroes.SpellFactory.MultiClass;
using LineageOfHeroes.SpellFactory.Summoner;
using LineageOfHeroes.Spells;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory
{
	public class SpellFactory : MonoBehaviour
	{
		[SerializeField] private BerzerkerSpellFactory berzerkerSpellFactory;
		[SerializeField] private MagiSpellFactory magiSpellFactory;
		[SerializeField] private SummonerSpellFactory summonerSpellFactory;
		[SerializeField] private MultiClassSpellFactory multiClassSpellFactory;

		private Dictionary<SpellType, Func<string, SpellBase>> factoryMap;

		private void Awake()
		{
			factoryMap = new Dictionary<SpellType, Func<string, SpellBase>>
				{
						{ SpellType.Berzerker, formattedSpellName => CreateSpell<BerzerkerSpellType>(formattedSpellName, berzerkerSpellFactory.CreateBerzerkerSpell) },
						{ SpellType.Magi, formattedSpellName => CreateSpell<MagiSpellType>(formattedSpellName, magiSpellFactory.CreateMagiSpell) },
						{ SpellType.Summoner, formattedSpellName => CreateSpell<SummonerSpellType>(formattedSpellName, summonerSpellFactory.CreateSummonerSpell) },
						{ SpellType.MultiClass, formattedSpellName => CreateSpell<MultiClassSpellType>(formattedSpellName, multiClassSpellFactory.CreateMultiClassSpell) }
				};
		}

		public SpellBase CreateSpell(SpellData spellData)
		{
			if (factoryMap == null)
			{
				Awake();
			}
			string formattedSpellName = spellData.displayName.Replace(" ", "");
			if (factoryMap.TryGetValue(spellData.spellType, out var factoryMethod))
			{
				return factoryMethod(formattedSpellName);
			}
			throw new ArgumentException($"Invalid spell type: {spellData.spellType}");
		}

		private SpellBase CreateSpell<T>(string formattedSpellName, Func<T, SpellBase> createMethod) where T : struct, Enum
		{
			if (Enum.TryParse(formattedSpellName, out T spellType))
			{
				return createMethod(spellType);
			}
			throw new ArgumentException($"Expected a {typeof(T).Name} instead received {formattedSpellName}");
		}
	}
}
