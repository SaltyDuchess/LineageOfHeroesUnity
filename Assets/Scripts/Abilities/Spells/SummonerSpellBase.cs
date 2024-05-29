using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells.Summoner
{
	public class SummonerSpellBase : SpellBase
	{
		[SerializeField] SummonerSpellData summonerSpellData;
		public SummonerSpellType summonerType { get; set; }

		new protected virtual void Awake()
		{
			base.spellData = summonerSpellData;
			base.Awake();
			summonerType = summonerSpellData.summonerSpellType;
		}
	}
}