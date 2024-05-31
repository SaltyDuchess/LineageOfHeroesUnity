using System;
using System.Collections.Generic;
using LineageOfHeroes.ConsumableTypes.PotionType;
using UnityEngine;

public class PotionFactory : MonoBehaviour
{
    [SerializeField] private List<PotionPrefabMapping> potionPrefabs;

    private Dictionary<PotionType, PotionBase> potionPrefabDict;

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        potionPrefabDict = new Dictionary<PotionType, PotionBase>();
        foreach (var mapping in potionPrefabs)
        {
            if (mapping.potionPrefab != null)
            {
                potionPrefabDict[mapping.potionType] = mapping.potionPrefab;
            }
        }
    }

    public PotionBase CreatePotion(PotionType potionType)
    {
        if (potionPrefabDict == null)
        {
            InitializeDictionary();
        }

        if (potionPrefabDict.TryGetValue(potionType, out var prefab))
        {
            return Instantiate(prefab);
        }
        throw new ArgumentException($"Invalid potion type: {potionType}");
    }

    [Serializable]
    public struct PotionPrefabMapping
    {
        public PotionType potionType;
        public PotionBase potionPrefab;
    }
}
