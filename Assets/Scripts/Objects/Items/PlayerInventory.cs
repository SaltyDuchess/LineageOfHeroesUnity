using System.Collections.Generic;
using UnityEngine;

namespace LineageOfHeroes.Items
{
	public class PlayerInventory : MonoBehaviour
	{
		private AbilityManager abilityManager;
		private List<EquipmentData> equipmentList;
		private List<ConsumableData> consumableList;

		public List<EquipmentData> EquipmentList
		{
			get => equipmentList;
			set => equipmentList = value;
		}

		public List<ConsumableData> ConsumableList
		{
			get => consumableList;
			set => consumableList = value;
		}

		public PlayerInventory()
		{
			EquipmentList = new List<EquipmentData>();
			ConsumableList = new List<ConsumableData>();
		}

		private void Awake()
		{
			abilityManager = FindObjectOfType<AbilityManager>();
		}

		public void AddEquipment(EquipmentData equipment)
		{
			EquipmentList.Add(equipment);
			// Custom logic for when equipment is added
		}

		public void AddConsumable(ConsumableData consumable)
		{
			ConsumableData existingConsumable = ConsumableList.Find(c => c.displayName == consumable.displayName);
			if (existingConsumable != null)
			{
				Debug.Log($"Added 1 {existingConsumable.displayName}, quantity: {existingConsumable.quantity}");
				existingConsumable.quantity++;
				return;
			}
			ConsumableList.Add(consumable);
			consumable.quantity++;
			abilityManager.UnlockAbility(consumable.displayName);
		}
	}
}
