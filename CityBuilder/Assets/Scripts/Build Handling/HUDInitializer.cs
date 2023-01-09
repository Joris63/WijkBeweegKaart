using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataController;

public class HUDInitializer : MonoBehaviour
{
    [SerializeField] private GameObject buildingButtonPrefab;
    [SerializeField] private RectTransform buttonsContainer;

    private BuildController buildController;
    private DataController dataController;

    private void Awake()
    {
        buildController = FindObjectOfType<BuildController>();
        dataController = FindObjectOfType<DataController>();
        if (buildController && dataController) InitializeHUD();
    }

    private void InitializeHUD()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        List<AvailableBuilding> buildings = dataController.AvailableBuildings;
#else
        // Debugging
        List<AvailableBuilding> buildings = new List<AvailableBuilding>() {
            new AvailableBuilding() { name = "Football", imageName = "Football" },
            new AvailableBuilding() { name = "Basketball", imageName = "Basketball" },
            new AvailableBuilding() { name = "Tennis", imageName = "Tennis" },
            new AvailableBuilding() { name = "Volleyball", imageName = "Volleyball" },
            new AvailableBuilding() { name = "Playground", imageName = "Playground" }
        };
#endif

        foreach (AvailableBuilding building in buildings)
        {
            GameObject buttonClone = Instantiate(buildingButtonPrefab, buttonsContainer);
            buttonClone.GetComponent<RectTransform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = building.name;

            buttonClone.GetComponent<Button>().onClick.AddListener(delegate { buildController.StartBuilding(building.imageName); });
        }

        GridLayoutGroup grid = buttonsContainer.GetComponent<GridLayoutGroup>();
        float extraSize = buildings.Count * grid.cellSize.y + (buildings.Count - 1) * grid.spacing.y - buttonsContainer.rect.height;
        if (extraSize > 0) buttonsContainer.offsetMin = new Vector2(buttonsContainer.offsetMin.x, -extraSize);
    }
}
