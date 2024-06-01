using LineageOfHeroes.Spells.SpellTypes;

namespace LineageOfHeroes.Spells
{
    public class SpellBase : AbilityBase, ISpell
    {
        public SpellData spellData;
        public SpellType type { get; set; }
        public float physDamageModifier { get; set; }
        public float magicDamageModifier { get; set; }
        public float DOT { get; set; }
        public int DOTTurns { get; set; }
        public int stunTurns { get; set; }
        private TooltipTrigger tooltipTrigger;

        protected override void Awake()
        {
            base.Awake();
            // Assign properties from SpellData to corresponding properties in the SpellBase class
            displayName = spellData.displayName;
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
        }

        public override void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
        {
            castingCreature.currentAbilityPool -= abilityPowerCost;
            currentCooldown = cooldown;
            castingCreature.queuedAbility = null;
        }
    }
}
