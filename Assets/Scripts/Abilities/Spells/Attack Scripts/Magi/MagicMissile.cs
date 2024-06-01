using LineageOfHeroes.AttackScripts;
using UnityEngine;

namespace LineageOfHeroes.Spells.Magi
{
	public class MagicMissile : MagiSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 2;
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to the nearest enemy.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			DealMagicDamageToCreature.DealMagicDamage(castingCreature, defender, spellData.magicDamageModifier);
		}
	}
}
