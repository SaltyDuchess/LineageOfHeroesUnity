using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
	public static TooltipController Instance { get; private set; }

	private TextMeshProUGUI tooltipText;
	private Image tooltipBackground;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		tooltipBackground = GetComponentInChildren<Image>();
		tooltipText = GetComponentInChildren<TextMeshProUGUI>();
		tooltipText.enabled = false;
		tooltipBackground.enabled = false;
	}

	public void ShowTooltip(string text, Vector3 position)
	{
		tooltipText.text = text;
		tooltipText.enabled = true;
		tooltipBackground.enabled = true;
	}

	public void HideTooltip()
	{
		tooltipText.enabled = false;
		tooltipBackground.enabled = false;
	}
}
