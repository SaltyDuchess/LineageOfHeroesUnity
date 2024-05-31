using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.BootType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Boot
{
    public class BootFactory : MonoBehaviour
    {
        [SerializeField] private List<BootPrefabMapping> bootPrefabs;

        private Dictionary<BootType, LineageOfHeroes.Items.Boot> bootPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            bootPrefabDict = new Dictionary<BootType, LineageOfHeroes.Items.Boot>();
            foreach (var mapping in bootPrefabs)
            {
                if (mapping.bootPrefab != null)
                {
                    bootPrefabDict[mapping.bootType] = mapping.bootPrefab;
                }
            }
        }

        public EquipmentBase CreateBoot(BootType bootType)
        {
            if (bootPrefabDict == null)
            {
                InitializeDictionary();
            }

            if (bootPrefabDict.TryGetValue(bootType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid boot type: {bootType}");
        }

        [Serializable]
        public struct BootPrefabMapping
        {
            public BootType bootType;
            public LineageOfHeroes.Items.Boot bootPrefab;
        }
    }
}
