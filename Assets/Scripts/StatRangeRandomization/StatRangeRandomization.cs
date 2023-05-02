using UnityEngine;
using System;

[Serializable]
public class StatRange
{
    public float minValue;
    public float maxValue;

    public float GetMinValue()
    {
        return minValue;
    }

    public void SetMinValue(float value)
    {
        minValue = value;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }

    public void SetMaxValue(float value)
    {
        maxValue = value;
    }
    public float GetRandomValue()
    {
        return UnityEngine.Random.Range(minValue, maxValue);
    }
}

public class RandomStatsExample : MonoBehaviour
{
    [SerializeField] private StatRange[] statRanges;
    [SerializeField] private float[] randomStats;

    [ContextMenu("Generate Random Stats")]
    private void GenerateRandomStats()
    {
        if (statRanges.Length == 0)
        {
            Debug.LogWarning("No stat ranges defined.");
            return;
        }

        randomStats = new float[statRanges.Length];

        for (int i = 0; i < statRanges.Length; i++)
        {
            randomStats[i] = statRanges[i].GetRandomValue();
        }
    }
}
