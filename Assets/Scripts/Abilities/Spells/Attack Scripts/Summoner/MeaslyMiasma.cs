using LineageOfHeroes.AttackScripts;

namespace LineageOfHeroes.Spells.Summoner
{
	public class MeaslyMiasma : SummonerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			magicDamageModifier = 1;
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Deals {magicDamageModifier * 100} magic damage to all enemies";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);
			Mob[] mobs = FindObjectsOfType<Mob>();
			
			DealMagicDamageToCreature.DealGlobalAOEMagicDamage(castingCreature, mobs, spellData.magicDamageModifier);
		}
	}
}
