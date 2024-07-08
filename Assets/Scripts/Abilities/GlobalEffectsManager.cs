using System;
using UnityEngine;

public class GlobalEffectsManager : MonoBehaviour
{
	public static GlobalEffectsManager Instance { get; private set; }

	public event Action<float> OnPlayerPercentageHPBoostChanged;

	private float playerPercentageHPBoost;

	public float PlayerPercentageHPBoost
	{
		get => playerPercentageHPBoost;
		set
		{
			playerPercentageHPBoost = value;
			OnPlayerPercentageHPBoostChanged?.Invoke(playerPercentageHPBoost);
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
