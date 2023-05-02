using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
    [CreateAssetMenu(fileName = "MagiData", menuName = "CharacterClasses/Magi", order = 2)]
    public class Magi : CharacterClass
    {
        public ClassSpellLibrary magiSpellLibrary;

        private void Awake()
        {
            classSpells = magiSpellLibrary.classSpells;
        }

        public override void ModifyPlayerStats(Player player)
        {
            // Modify player stats for Magi class here when needed
        }
    }
}
