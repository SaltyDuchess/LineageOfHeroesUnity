using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BigHealthBarController : MonoBehaviour
{
	private Image healthBarImage;
	private Player player;
	private TextMeshProUGUI percentageText;
	void Start()
	{
		healthBarImage = transform.Find("ForegroundImage").GetComponent<Image>();
		player = FindObjectOfType<Player>();
		percentageText = transform.GetComponentInChildren<TextMeshProUGUI>();
	}
	// Update is called once per frame
	void Update()
	{
		// Update health bar fill amount
		float percentageHealth = player.currentHealth / player.healthPool;
		healthBarImage.fillAmount = percentageHealth;

		// Update health bar color
		Color healthColor = Color.red;

		if (percentageHealth > 0.66f)
		{
			healthColor = Color.green;
		}
		else if (percentageHealth > 0.33f)
		{
			healthColor = Color.yellow;
		}

		healthBarImage.color = healthColor;
		percentageText.text = percentageHealth * 100 + "%";
	}
}
