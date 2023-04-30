using UnityEngine;

namespace LineageOfHeroes.Spells.Summoner
{
	public class PiedPiper : SpellBase, ISpell
	{
			public void PiedPiperScript(Creature castingCreature)
			{
					castingCreature.currentAbilityPool -= abilityPowerCost;

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

					currentCooldown = cooldown;
			}
	}
}
