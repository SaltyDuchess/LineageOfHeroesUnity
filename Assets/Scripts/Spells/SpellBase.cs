using LineageOfHeroes.Spells.SpellTypes;
using UnityEngine;

namespace LineageOfHeroes.Spells
{
	public class SpellBase : MonoBehaviour, ISpell
	{
		public SpellData spellData;
		public SpellType type { get; set; }
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
		private TooltipTrigger tooltipTrigger;

		protected virtual void Awake()
		{
			// Assign properties from SpellData to corresponding properties in the SpellBase class
			displayName = spellData.spellName;
			uiElement = spellData.uiElement;
			cooldown = spellData.cooldown;
			levelRequirement = spellData.levelRequirement;
			instantCast = spellData.instantCast;
			abilityPowerCost = spellData.abilityPowerCost;
			physDamageModifier = spellData.physDamageModifier;
			magicDamageModifier = spellData.magicDamageModifier;
			DOT = spellData.DOT;
			DOTTurns = spellData.DOTTurns;
			stunTurns = spellData.stunTurns;

			// Get the reference to TooltipTrigger component
			tooltipTrigger = GetComponent<TooltipTrigger>();

			// Set the tooltipText using SetTooltipText method
			tooltipTrigger.SetTooltipText(descriptionLong);
		}

		public virtual void ExecuteSpell(Creature castingCreature = null, Creature defender = null)
		{
			castingCreature.stats.currentAbilityPool -= abilityPowerCost;
			currentCooldown = cooldown;
		}
	}
}
