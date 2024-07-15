using System.Collections;
using LineageOfHeroes.AttackScripts;
using LineageOfHeroes.Spells.Berzerker;
using UnityEngine;

public class SappingSlam : BerzerkerSpellBase
{
    public int maxDistance = 10;

    new private void Awake()
    {
        base.Awake();
        descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Dash in the direction last moved until colliding with a Mob. Deal {physDamageModifier * 100}% more damage,"
				+ $" {spellData.critDamageModifier * 100}% crit damage, and have {spellData.critChanceModifier}% crit chance increased for each square to a maximum of {maxDistance}. Stun self for 2 turns after.";
    }

    public override void ExecuteAbility(Creature castingCreature, Creature defender = null)
    {
        base.ExecuteAbility(castingCreature, defender);
        StartCoroutine(DashAndAttack(castingCreature));
    }

    private IEnumerator DashAndAttack(Creature castingCreature)
    {
        Vector2 direction = castingCreature.GetComponent<PlayerMovement>().lastMoveDirection;
        Vector2 startPosition = castingCreature.transform.position;
        RaycastHit2D hit;

        for (int i = 1; i <= maxDistance; i++)
        {
            Vector2 nextPosition = startPosition + direction * i;
            hit = Physics2D.Raycast(nextPosition, Vector2.zero);

            if (hit.collider != null)
            {
                Mob targetMob = hit.collider.GetComponent<Mob>();
                if (targetMob != null)
                {
                    float distanceTraveled = Vector2.Distance(startPosition, hit.point);
                    ApplyEffects(castingCreature, targetMob, distanceTraveled);
                    break;
                }
                else
                {
                    castingCreature.transform.position = hit.point;
                    break;
                }
            }
            castingCreature.transform.position = nextPosition;
            yield return new WaitForSeconds(0.05f);
        }
        castingCreature.GetComponent<Player>().speedPool -= 100 * stunTurns;
    }

    private void ApplyEffects(Creature castingCreature, Creature target, float distance)
    {
        float bonusDamage = distance * physDamageModifier;
        float bonusCritChance = distance * spellData.critChanceModifier;
        float bonusCritDamage = distance * spellData.critDamageModifier;

        castingCreature.critChanceModifier += bonusCritChance;
        castingCreature.critDamageMultiplier += bonusCritDamage;

        DealPhysicalDamageToCreature.DealPhysicalDamage(castingCreature, target, bonusDamage);

        castingCreature.critChanceModifier -= bonusCritChance;
        castingCreature.critDamageMultiplier -= bonusCritDamage;
    }
}
