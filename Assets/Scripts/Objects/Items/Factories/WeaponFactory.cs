using System;
using System.Collections.Generic;
using LineageOfHeroes.Items;
using LineageOfHeroes.ItemTypes.WeaponType;
using UnityEngine;

namespace LineageOfHeroes.ItemFactories.Weapon
{
    public class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private List<WeaponPrefabMapping> weaponPrefabs;

        private Dictionary<WeaponType, LineageOfHeroes.Items.Weapon> weaponPrefabDict;

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            weaponPrefabDict = new Dictionary<WeaponType, LineageOfHeroes.Items.Weapon>();
            foreach (var mapping in weaponPrefabs)
            {
                if (mapping.weaponPrefab != null)
                {
                    weaponPrefabDict[mapping.weaponType] = mapping.weaponPrefab;
                }
            }
        }

        public EquipmentBase CreateWeapon(WeaponType weaponType)
        {
            if (weaponPrefabDict == null)
            {
                InitializeDictionary(); // Ensure the dictionary is initialized
            }

            if (weaponPrefabDict.TryGetValue(weaponType, out var prefab))
            {
                return Instantiate(prefab);
            }
            throw new ArgumentException($"Invalid weapon type: {weaponType}");
        }

        [Serializable]
        public struct WeaponPrefabMapping
        {
            public WeaponType weaponType;
            public LineageOfHeroes.Items.Weapon weaponPrefab;
        }
    }
}
