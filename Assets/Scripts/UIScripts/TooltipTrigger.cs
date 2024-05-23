using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string tooltipText;
    private TooltipController tooltipController;

    private void Start()
    {
        tooltipController = FindObjectOfType<TooltipController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipController.ShowTooltip(tooltipText, eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipController.HideTooltip();
    }

		public void SetTooltipText(string newText)
		{
			tooltipText = newText;
		}
}
