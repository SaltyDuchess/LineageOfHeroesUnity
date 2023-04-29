using UnityEngine;

public class CalcCritAndDamage : MonoBehaviour
{
    public DamageSystem damageSystem; // Drag and drop the DamageSystem object in the Unity editor

    public float CalculateCritAndDamage(Creature attacker)
    {
        float universalCritChance = damageSystem.universalCritChance;
        float universalCritMultiplier = damageSystem.universalCritMultiplier;
        float finalCritChance = universalCritChance + attacker.critChanceModifier;

        if (Random.Range(1, 101) <= finalCritChance)
        {
            return universalCritMultiplier + attacker.critDamageMultiplier;
        }
        else
        {
            return 1;
        }
    }
}