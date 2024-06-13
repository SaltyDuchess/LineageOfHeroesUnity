using LineageOfHeroes.AttackScripts;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class AbductingAssault : TargetedSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Pulls the targeted enemy next to the player.";
		}

		protected override void ApplySpellEffect(Creature castingCreature, Creature target)
		{
			MoveTarget.PullTargetTowards(castingCreature, target);
		}
	}
}
