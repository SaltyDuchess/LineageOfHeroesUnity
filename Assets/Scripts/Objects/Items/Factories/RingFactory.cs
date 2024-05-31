using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.RingType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Ring
{
    public class RingFactory : MonoBehaviour
    {
        [SerializeField] private List<RingPrefabMapping> ringPrefabs;

        private Dictionary<RingType, LineageOfHeroes.Items.Ring> ringPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            ringPrefabDict = new Dictionary<RingType, LineageOfHeroes.Items.Ring>();
            foreach (var mapping in ringPrefabs)
            {
                if (mapping.ringPrefab != null)
                {
                    ringPrefabDict[mapping.ringType] = mapping.ringPrefab;
                }
            }
        }

        public EquipmentBase CreateRing(RingType ringType)
        {
            if (ringPrefabDict == null)
            {
                InitializeDictionary();
            }

            if (ringPrefabDict.TryGetValue(ringType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid ring type: {ringType}");
        }

        [Serializable]
        public struct RingPrefabMapping
        {
            public RingType ringType;
            public LineageOfHeroes.Items.Ring ringPrefab;
        }
    }
}
