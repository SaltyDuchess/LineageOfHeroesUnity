using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace LineageOfHeroes.Spells
{
	public abstract class TargetedSpellBase : SpellBase
	{
		public Creature selectedTarget;
		protected int targetIndex = 0;
		private SpriteRenderer targetedCreatureSpriteRenderer;
		private Color originalTargetedCreatureColor;
		public Color targetedColor = Color.red;

		protected override void Awake()
		{
			base.Awake();
			selectedTarget = null;
		}

		public override bool IsCastable(Creature castingCreature)
		{
			return castingCreature.currentAbilityPool >= abilityPowerCost;
		}

		public override void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
		{
			if (selectedTarget != null)
			{
				castingCreature.currentAbilityPool -= abilityPowerCost;
				currentCooldown = cooldown;
				castingCreature.queuedAbility = null;
				ApplySpellEffect(castingCreature, selectedTarget);
			}
		}

		protected abstract void ApplySpellEffect(Creature castingCreature, Creature target);

		public void SelectNextTarget()
		{
			if (selectedTarget != null) targetedCreatureSpriteRenderer.color = originalTargetedCreatureColor;
			var enemies = FindObjectsOfType<Mob>();
			if (enemies.Length == 0) return;

			targetIndex = (targetIndex + 1) % enemies.Length;
			selectedTarget = enemies[targetIndex];

			targetedCreatureSpriteRenderer = selectedTarget.GetComponent<SpriteRenderer>();
			// targetedCreatureImage = selectedTargetSpriteRenderer.GetComponent<Image>();
			originalTargetedCreatureColor = targetedCreatureSpriteRenderer.color;

			// Update the UI or highlight to indicate the selected target
			HighlightTarget();
		}

		private void HighlightTarget()
		{
			// Implement your logic to visually highlight the selected target (e.g., show an X over the target)
			targetedCreatureSpriteRenderer.color = targetedColor;
		}

		public void ConfirmTargetAndCast()
		{
			if (selectedTarget != null)
			{
				targetedCreatureSpriteRenderer.color = originalTargetedCreatureColor;
				ExecuteAbility(FindObjectOfType<Player>(), selectedTarget);
				selectedTarget = null;
			}
		}
	}
}
