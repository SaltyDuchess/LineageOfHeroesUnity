using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.ShoulderType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Shoulder
{
    public class ShoulderFactory : MonoBehaviour
    {
        [SerializeField] private List<ShoulderPrefabMapping> shoulderPrefabs;

        private Dictionary<ShoulderType, LineageOfHeroes.Items.Shoulder> shoulderPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            shoulderPrefabDict = new Dictionary<ShoulderType, LineageOfHeroes.Items.Shoulder>();
            foreach (var mapping in shoulderPrefabs)
            {
                if (mapping.shoulderPrefab != null)
                {
                    shoulderPrefabDict[mapping.shoulderType] = mapping.shoulderPrefab;
                }
            }
        }

        public EquipmentBase CreateShoulder(ShoulderType shoulderType)
        {
            if (shoulderPrefabDict == null)
            {
                InitializeDictionary();
            }

            if (shoulderPrefabDict.TryGetValue(shoulderType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid shoulder type: {shoulderType}");
        }

        [Serializable]
        public struct ShoulderPrefabMapping
        {
            public ShoulderType shoulderType;
            public LineageOfHeroes.Items.Shoulder shoulderPrefab;
        }
    }
}
