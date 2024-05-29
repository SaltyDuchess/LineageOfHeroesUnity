using LineageOfHeroes.ConsumableTypes;
using UnityEngine;

public interface IConsumable : IAbility
{
	public int quantity { get; set; }
	public ConsumableType type { get; set; }
	public Rarity consumableRarity { get; set; }
	[System.Serializable]
	public struct ConsumableDrop
	{
		public ConsumableBase consumable;
		public float dropWeight;
	}
}
