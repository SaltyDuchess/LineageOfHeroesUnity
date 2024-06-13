using UnityEngine;

namespace LineageOfHeroes.Spells.Berzerker
{
	public class HemorrhagicHaste : BerzerkerSpellBase
	{
		[SerializeField] protected int hpCost = 5;
		[SerializeField] protected int speedIncrease = 50;
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - 5 HP per turn --- Required Level - {levelRequirement}\nDescription - Increases the player's current speed pool by 50 per turn while sustained.";
		}

		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			if (castingCreature is Player player)
			{
				player.currentHealth -= hpCost;
				if (player.currentHealth < 0)
				{
					player.currentHealth = 0;
				}

				player.speedPool += speedIncrease;
			}
		}
	}
}
