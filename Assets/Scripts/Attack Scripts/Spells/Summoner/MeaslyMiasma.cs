using LineageOfHeroes.Items;
using UnityEngine;

namespace LineageOfHeroes.Spells.Summoner
{
	public class MeaslyMiasma : SpellBase, ISpell
	{
			new private void Awake()
			{
				base.Awake();
				magicDamageModifier = 1;
			}

			public void MeaslyMiasmaScript(ICreature castingCreature, PlayerEquipment playerEquipment)
			{
					castingCreature.currentAbilityPool -= abilityPowerCost;
					float damage;

					if (playerEquipment.equippedWeapon != null)
					{
							damage = playerEquipment.GetDamageValue() + playerEquipment.GetDamageValue() * magicDamageModifier;
							damage *= calcCritAndDamage.CalculateCritAndDamage(playerEquipment.equippedWeapon);
					}
					else
					{
							damage = castingCreature.GetDamageValue() + castingCreature.GetDamageValue() * magicDamageModifier;
							damage *= calcCritAndDamage.CalculateCritAndDamage(castingCreature);
					}

					Mob[] mobs = FindObjectsOfType<Mob>();

					foreach (Mob defender in mobs)
					{
							float finalDamage = damage - (damage * defender.magicDamageResist);
							defender.currentHealth -= finalDamage;
					}

					currentCooldown = cooldown;
			}
	}
}
