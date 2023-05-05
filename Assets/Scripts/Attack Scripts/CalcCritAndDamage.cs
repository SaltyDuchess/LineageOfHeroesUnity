using LineageOfHeroes.Randomization;
using UnityEngine;

public class CalcCritAndDamage : MonoBehaviour
{
    public DamageSystem damageSystem; // Drag and drop the DamageSystem object in the Unity editor

	public float CalculateCritAndDamage<T>(T attacker) where T : Creature
	{
			float universalCritChance = damageSystem.universalCritChance;
			float universalCritMultiplier = damageSystem.universalCritMultiplier;
			float finalCritChance = universalCritChance + attacker.critChanceModifier;

			if (RandomGenerator.Range(1, 101) <= finalCritChance)
			{
					return universalCritMultiplier + attacker.critDamageMultiplier;
			}
			else
			{
					return 1;
			}
	}
}