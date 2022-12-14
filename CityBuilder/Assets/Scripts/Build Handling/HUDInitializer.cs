using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDInitializer : MonoBehaviour
{
    [System.Serializable]
    private class Building
    {
        public string name;
        public GameObject prefab;
    }

    [SerializeField] private RectTransform buttonsContainer;
    [SerializeField] private GameObject buildingButtonPrefab;
    [SerializeField] private List<Building> buildings = new List<Building>();

    private BuildController buildController;

    private void Awake()
    {
        buildController = FindObjectOfType<BuildController>();
        if (!buildController) return;

        foreach (Building building in buildings)
        {
            GameObject buttonClone = Instantiate(buildingButtonPrefab, buttonsContainer);
            buttonClone.GetComponent<RectTransform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = building.name;

            buttonClone.GetComponent<Button>().onClick.AddListener(delegate { buildController.StartBuilding(building.prefab); });
        }

        GridLayoutGroup grid = buttonsContainer.GetComponent<GridLayoutGroup>();
        float extraSize = buildings.Count * grid.cellSize.y + (buildings.Count - 1) * grid.spacing.y - buttonsContainer.rect.height;
        if (extraSize > 0) buttonsContainer.offsetMin = new Vector2(buttonsContainer.offsetMin.x, -extraSize);
    }
}
