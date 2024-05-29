using System;
using LineageOfHeroes.SpellFactory;
using UnityEngine;

public class AbilityFactory : MonoBehaviour
{
    public SpellFactory spellFactory;
    public ConsumableFactory consumableFactory;

    public AbilityBase CreateAbility(AbilityData abilityData)
    {
        if (abilityData is SpellData spellData)
        {
            return spellFactory.CreateSpell(spellData);
        }
        else if (abilityData is ConsumableData consumableData)
        {
            return consumableFactory.CreateConsumable(consumableData);
        }
        else
        {
            throw new ArgumentException("Unknown AbilityData type");
        }
    }
}
