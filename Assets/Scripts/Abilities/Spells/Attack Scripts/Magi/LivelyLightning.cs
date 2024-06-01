using LineageOfHeroes.AttackScripts;

namespace LineageOfHeroes.Spells.Magi
{
	public class LivelyLightning : MagiSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to the targeted enemy.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			DealMagicDamageToCreature.DealMagicDamage(castingCreature, defender, spellData.magicDamageModifier);
		}
	}
}
