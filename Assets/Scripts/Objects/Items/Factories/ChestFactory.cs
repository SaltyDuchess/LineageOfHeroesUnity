using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.ChestType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Chest
{
    public class ChestFactory : MonoBehaviour
    {
        [SerializeField] private List<ChestPrefabMapping> chestPrefabs;

        private Dictionary<ChestType, LineageOfHeroes.Items.Chest> chestPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            chestPrefabDict = new Dictionary<ChestType, LineageOfHeroes.Items.Chest>();
            foreach (var mapping in chestPrefabs)
            {
                if (mapping.chestPrefab != null)
                {
                    chestPrefabDict[mapping.chestType] = mapping.chestPrefab;
                }
            }
        }

        public EquipmentBase CreateChest(ChestType chestType)
        {
            if (chestPrefabDict == null)
            {
                InitializeDictionary();
            }

            if (chestPrefabDict.TryGetValue(chestType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid chest type: {chestType}");
        }

        [Serializable]
        public struct ChestPrefabMapping
        {
            public ChestType chestType;
            public LineageOfHeroes.Items.Chest chestPrefab;
        }
    }
}
