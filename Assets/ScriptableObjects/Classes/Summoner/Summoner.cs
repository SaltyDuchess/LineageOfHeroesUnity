using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
    [CreateAssetMenu(fileName = "SummonerData", menuName = "CharacterClasses/Summoner", order = 3)]
    public class Summoner : CharacterClass
    {
        public ClassSpellLibrary summonerSpellLibrary;

        private void Awake()
        {
            classSpells = summonerSpellLibrary.classSpells;
        }

        public override void ModifyPlayerStats(Player player)
        {
            // Modify player stats for Summoner class here when needed
        }
    }
}
