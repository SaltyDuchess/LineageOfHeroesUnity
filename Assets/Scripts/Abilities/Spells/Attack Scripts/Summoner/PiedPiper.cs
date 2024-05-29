using UnityEngine;

namespace LineageOfHeroes.Spells.Summoner
{
	public class PiedPiper : SummonerSpellBase
	{
		new private void Awake()
		{
			base.Awake();
			descriptionLong = $"{displayName} --- Cost - {abilityPowerCost} Stamina --- Required Level - {levelRequirement}\nDescription - Summons a rat familiar";
		}
		override public void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			base.ExecuteAbility(castingCreature, defender);

			Vector2[] offsets = new Vector2[]
			{
							new Vector2(32, 0),
							new Vector2(0, -32),
							new Vector2(0, 32),
							new Vector2(-32, 0),
							new Vector2(-32, -32),
							new Vector2(32, -32),
							new Vector2(32, 32),
							new Vector2(-32, 32)
			};

			foreach (Vector2 offset in offsets)
			{
				Vector3 newPosition = castingCreature.transform.position + (Vector3)offset;
				if (!Physics2D.OverlapCircle(newPosition, 0.1f))
				{
					Instantiate(Resources.Load("Familiar"), newPosition, Quaternion.identity);
					break;
				}
			}
		}
	}
}
