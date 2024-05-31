using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.GauntletType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Gauntlet
{
    public class GauntletFactory : MonoBehaviour
    {
        [SerializeField] private List<GauntletPrefabMapping> gauntletPrefabs;

        private Dictionary<GauntletType, LineageOfHeroes.Items.Gauntlet> gauntletPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            gauntletPrefabDict = new Dictionary<GauntletType, LineageOfHeroes.Items.Gauntlet>();
            foreach (var mapping in gauntletPrefabs)
            {
                if (mapping.gauntletPrefab != null)
                {
                    gauntletPrefabDict[mapping.gauntletType] = mapping.gauntletPrefab;
                }
            }
        }

        public EquipmentBase CreateGauntlet(GauntletType gauntletType)
        {
            if (gauntletPrefabDict == null)
            {
                InitializeDictionary();
            }

            if (gauntletPrefabDict.TryGetValue(gauntletType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid gauntlet type: {gauntletType}");
        }

        [Serializable]
        public struct GauntletPrefabMapping
        {
            public GauntletType gauntletType;
            public LineageOfHeroes.Items.Gauntlet gauntletPrefab;
        }
    }
}
