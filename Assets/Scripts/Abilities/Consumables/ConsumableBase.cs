using LineageOfHeroes.ConsumableTypes;
using LineageOfHeroes.Items;
using UnityEngine;

public class ConsumableBase : AbilityBase, IConsumable
{
    public int quantity { get; set; }
    public ConsumableType type { get; set; }
    public Rarity consumableRarity { get; set; }
    public ConsumableData consumableData;

    protected override void Awake()
    {
        base.Awake();
        displayName = consumableData.displayName;
        uiElement = consumableData.uiElement;
        cooldown = consumableData.cooldown;
        levelRequirement = consumableData.levelRequirement;
        instantCast = consumableData.instantCast;
        abilityPowerCost = consumableData.abilityPowerCost;
        consumableRarity = consumableData.consumableRarity;
        type = consumableData.consumableType;
        descriptionLong = consumableData.descriptionLong;
    }

		public override bool IsCastable(Creature castingCreature = null)
		{
			PlayerInventory playerInventory = castingCreature.GetComponent<PlayerInventory>();
			ConsumableData data = playerInventory.ConsumableList.Find(c => c.displayName == displayName);
			return data.quantity > 0;
		}

    public override void ExecuteAbility(Creature castingCreature = null, Creature defender = null)
    {
        PlayerInventory playerInventory = castingCreature.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            ConsumableData consumableData = playerInventory.ConsumableList.Find(c => c.displayName == displayName);
            if (consumableData != null && consumableData.quantity > 0)
            {
                consumableData.quantity--;
								Debug.Log($"Used 1 {consumableData.displayName}, quantity left: {consumableData.quantity}");
                castingCreature.currentAbilityPool -= abilityPowerCost;
                currentCooldown = cooldown;
                castingCreature.queuedAbility = null;
            }
        }
    }
}
