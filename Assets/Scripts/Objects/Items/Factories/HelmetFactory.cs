using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.HelmetType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Helmet
{
    public class HelmetFactory : MonoBehaviour
    {
        [SerializeField] private List<HelmetPrefabMapping> helmetPrefabs;

        private Dictionary<HelmetType, LineageOfHeroes.Items.Helmet> helmetPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            helmetPrefabDict = new Dictionary<HelmetType, LineageOfHeroes.Items.Helmet>();
            foreach (var mapping in helmetPrefabs)
            {
                if (mapping.helmetPrefab != null)
                {
                    helmetPrefabDict[mapping.helmetType] = mapping.helmetPrefab;
                }
            }
        }

        public EquipmentBase CreateHelmet(HelmetType helmetType)
        {
            if (helmetPrefabDict == null)
            {
                InitializeDictionary();
            }

            if (helmetPrefabDict.TryGetValue(helmetType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid helmet type: {helmetType}");
        }

        [Serializable]
        public struct HelmetPrefabMapping
        {
            public HelmetType helmetType;
            public LineageOfHeroes.Items.Helmet helmetPrefab;
        }
    }
}
