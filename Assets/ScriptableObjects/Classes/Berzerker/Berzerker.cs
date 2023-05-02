using UnityEngine;

namespace LineageOfHeroes.CharacterClasses
{
    [CreateAssetMenu(fileName = "BerzerkerData", menuName = "CharacterClasses/Berzerker", order = 1)]
    public class Berzerker : CharacterClass
    {
        public ClassSpellLibrary berzerkerSpellLibrary;

        private void Awake()
        {
            classSpells = berzerkerSpellLibrary.classSpells;
        }

        public override void ModifyPlayerStats(Player player)
        {
            // Example: Add 50 health points for Berzerker class
            player.stats.healthPool += 50;
            player.stats.currentHealth = player.stats.healthPool;
        }
    }
}
