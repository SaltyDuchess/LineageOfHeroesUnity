using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.CapeType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Cape
{
    public class CapeFactory : MonoBehaviour
    {
        [SerializeField] private List<CapePrefabMapping> capePrefabs;

        private Dictionary<CapeType, LineageOfHeroes.Items.Cape> capePrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            capePrefabDict = new Dictionary<CapeType, LineageOfHeroes.Items.Cape>();
            foreach (var mapping in capePrefabs)
            {
                if (mapping.capePrefab != null)
                {
                    capePrefabDict[mapping.capeType] = mapping.capePrefab;
                }
            }
        }

        public EquipmentBase CreateCape(CapeType capeType)
        {
            if (capePrefabDict == null)
            {
                InitializeDictionary();
            }

            if (capePrefabDict.TryGetValue(capeType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid cape type: {capeType}");
        }

        [Serializable]
        public struct CapePrefabMapping
        {
            public CapeType capeType;
            public LineageOfHeroes.Items.Cape capePrefab;
        }
    }
}
