using System;
using UnityEngine;

public class GlobalEffectsManager : MonoBehaviour
{
	public static GlobalEffectsManager Instance { get; private set; }
	public event Action<float> OnPlayerPercentageHPBoostChanged;
	public event Action<float> OnPlayerPercentageAbilityPowerBoostChanged;
	public bool bleedsCanCrit = false;
	public float bleedCritChance = 0f;
	public float bleedCritModifier = 0f;
	private float playerPercentageHPBoost;
	private float playerPercentageAbilityPowerBoost;

	public float PlayerPercentageHPBoost
	{
		get => playerPercentageHPBoost;
		set
		{
			playerPercentageHPBoost = value;
			OnPlayerPercentageHPBoostChanged?.Invoke(playerPercentageHPBoost);
		}
	}

	public float PlayerPercentageAbilityPowerBoost
	{
		get => playerPercentageAbilityPowerBoost;
		set
		{
			playerPercentageAbilityPowerBoost = value;
			OnPlayerPercentageAbilityPowerBoostChanged?.Invoke(playerPercentageAbilityPowerBoost);
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
