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
        Debug.Log("TooltipTrigger attached and initialized for: " + gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered: " + gameObject.name);
        tooltipController.ShowTooltip(tooltipText, eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited: " + gameObject.name);
        tooltipController.HideTooltip();
    }

		public void SetTooltipText(string newText)
		{
			tooltipText = newText;
		}
}
