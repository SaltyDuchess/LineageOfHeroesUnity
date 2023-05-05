using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public float offsetX = -31.0f;

    private ICreature creature;
    private RectTransform healthBarRectTransform;
    private Image healthBarForegroundImage;
    private Canvas canvas;

    void Start()
    {
        creature = GetComponent<ICreature>();

        canvas = FindObjectOfType<Canvas>();
        GameObject healthBarObject = Instantiate(healthBarPrefab, canvas.transform);
				creature.healthBarObject = healthBarObject;
        healthBarRectTransform = healthBarObject.GetComponent<RectTransform>();
        healthBarForegroundImage = healthBarObject.transform.Find("Foreground").GetComponent<Image>();
        healthBarForegroundImage.type = Image.Type.Filled;
        healthBarForegroundImage.fillMethod = Image.FillMethod.Vertical;
    }

    void Update()
    {
        // Convert world position to screen space and apply offset in screen space
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition += new Vector3(offsetX, 0, 0);
        healthBarRectTransform.position = screenPosition;

        // Update health bar fill amount
        float percentageHealth = creature.currentHealth / creature.healthPool;
        healthBarForegroundImage.fillAmount = percentageHealth;

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

        healthBarForegroundImage.color = healthColor;
    }
}
