using System;
using LineageOfHeroes.Spells.Berzerker;
using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.SpellFactory.Berzerker
{
    public class BerzerkerSpellFactory : MonoBehaviour
    {
        [SerializeField] private BeastlyBite beastlyBitePrefab;
        [SerializeField] private FatalFinish fatalFinishPrefab;
        [SerializeField] private InstantImmolation instantImmolationPrefab;
        [SerializeField] private SanguinarySwap sanguinarySwapPrefab;
        [SerializeField] private StunningStrike stunningStrikePrefab;
        [SerializeField] private WeepingWounds weepingWoundsPrefab;

        public BerzerkerSpellBase CreateBerzerkerSpell(BerzerkerSpellType spellType)
        {
            switch (spellType)
            {
                case BerzerkerSpellType.BeastlyBite:
                    return Instantiate(beastlyBitePrefab);
                case BerzerkerSpellType.FatalFinish:
                    return Instantiate(fatalFinishPrefab);
                case BerzerkerSpellType.InstantImmolation:
                    return Instantiate(instantImmolationPrefab);
                case BerzerkerSpellType.SanguinarySwap:
                    return Instantiate(sanguinarySwapPrefab);
                case BerzerkerSpellType.StunningStrike:
                    return Instantiate(stunningStrikePrefab);
                case BerzerkerSpellType.WeepingWound:
                    return Instantiate(weepingWoundsPrefab);
                default:
                    throw new ArgumentException($"Invalid berzerker spell type: {spellType}");
            }
        }
    }
}
