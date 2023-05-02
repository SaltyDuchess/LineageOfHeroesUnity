using LineageOfHeroes.Spells;
using UnityEngine;

namespace LineageOfHeroes.Spells
{
	public class SpellBase : MonoBehaviour, ISpell
	{
			[SerializeField] protected SpellData spellData;

			public string displayName { get; set; }
			public Sprite uiElement { get; set; }
			public int cooldown { get; set; }
			public int currentCooldown { get; set; }
			public int levelRequirement { get; set; }
			public string descriptionLong { get; set; }
			public bool instantCast { get; set; }
			public float abilityPowerCost { get; set; }
			public bool isCastable { get; set; }
			public Creature targetedEnemy { get; set; }

			public float physDamageModifier { get; set; }
			public float magicDamageModifier { get; set; }
			public float DOT { get; set; }
			public int DOTTurns { get; set; }
			public int stunTurns { get; set; }
			public CalcCritAndDamage calcCritAndDamage { get; set; }

			protected virtual void Awake()
			{
					// Assign properties from SpellData to corresponding properties in the SpellBase class
					displayName = spellData.spellName;
					uiElement = spellData.uiElement;
					cooldown = spellData.cooldown;
					levelRequirement = spellData.levelRequirement;
					descriptionLong = spellData.descriptionLong;
					instantCast = spellData.instantCast;
					abilityPowerCost = spellData.abilityPowerCost;
			}

			public virtual void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
			{
				castingCreature.stats.currentAbilityPool -= abilityPowerCost;
				currentCooldown = cooldown;
			}
	}
}
