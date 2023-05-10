using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarController : MonoBehaviour
{
	private Image staminaBarImage;
	private Player player;
	private TextMeshProUGUI percentageText;
	void Start()
	{
		staminaBarImage = transform.Find("ForegroundImage").GetComponent<Image>();
		player = FindObjectOfType<Player>();
		percentageText = transform.GetComponentInChildren<TextMeshProUGUI>();
	}
	// Update is called once per frame
	void Update()
	{
		float percentageAbilityPower = player.currentAbilityPool / player.abilityPowerPool;
		staminaBarImage.fillAmount = percentageAbilityPower;
		percentageText.text = percentageAbilityPower * 100 + "%";
	}
}
