using UnityEngine;
using UnityEngine.UI;

public class AbilityBoxGridController : MonoBehaviour
{
    public GameObject abilityBoxPrefab;
    private RectTransform rectTransform;
    private GridLayoutGroup gridLayoutGroup;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        CreateAbilityBoxes();
    }

    void CreateAbilityBoxes()
    {
        float gridWidth = rectTransform.rect.width;
        float gridHeight = rectTransform.rect.height;

        float cellWidth = gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x;
        float cellHeight = gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y;

        int maxColumns = Mathf.FloorToInt(gridWidth / cellWidth);
        int maxRows = Mathf.FloorToInt(gridHeight / cellHeight);

        int totalBoxes = maxColumns * maxRows;

        for (int i = 0; i < totalBoxes; i++)
        {
            GameObject abilityBox = Instantiate(abilityBoxPrefab, transform);
        }
    }
}
