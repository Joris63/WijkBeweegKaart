using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataController;

public class RatingController : MonoBehaviour
{
    [SerializeField] private int buildingSizeMultiplier = 1;
    [SerializeField] private Vector3 scaleOnSelected;

    [Space(12)]
    [SerializeField] private GameObject ratingMenu;
    [SerializeField] private GameObject buildingObjectPrefab;

    private DataController dataController;
    private TextMeshProUGUI infoText;

    private Dictionary<GameObject, int> buildingPoints = new Dictionary<GameObject, int>();
    private GameObject currentSelected = null;

    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
        if (dataController) OnDataRetrieved();
        infoText = ratingMenu.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!dataController) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 200f) && hit.transform.parent == transform)
            {
                if (currentSelected) currentSelected.transform.localScale = Vector3.one * buildingSizeMultiplier;
                currentSelected = hit.transform.gameObject;
                currentSelected.transform.localScale = scaleOnSelected;

                ratingMenu.transform.position = currentSelected.transform.position;
                infoText.text = "<b>" + currentSelected.name.ToLower() + "</b>\npoints: " + buildingPoints[currentSelected];
                ratingMenu.SetActive(true);
            }
            else if (currentSelected)
            {
                currentSelected.transform.localScale = Vector3.one * buildingSizeMultiplier;
                currentSelected = null;

                ratingMenu.SetActive(false);
            }
        }
    }

    private void OnDataRetrieved()
    {
        foreach (PlacedBuilding building in dataController.SavedBuildings)
        {
            Texture2D text = LoadTexture(building.name);
            if (text == null) continue;

            Sprite buildingSprite = Sprite.Create(text, new Rect(0, 0, text.width, text.height), Vector2.zero, 100f);

            Transform buildingClone = Instantiate(buildingObjectPrefab).transform;
            buildingClone.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = buildingSprite;
            buildingClone.parent = transform;
            buildingClone.position = building.position;
            buildingClone.eulerAngles = building.rotation;
            buildingClone.name = building.name;
            buildingClone.localScale *= buildingSizeMultiplier;

            buildingPoints.Add(buildingClone.gameObject, building.totalPoints);
        }
    }

    private Texture2D LoadTexture(string imageName)
    {
        string path = Application.streamingAssetsPath + "/Buildings/" + imageName + ".png";
        if (File.Exists(path))
        {
            Texture2D text = new Texture2D(1, 1);
            if (text.LoadImage(File.ReadAllBytes(path)))
            {
                return text;
            }
        }
        return null;
    }

    public void GivePoint()
    {
        if (currentSelected)
        {
            buildingPoints[currentSelected]++;
            infoText.text = "<b>" + currentSelected.name.ToLower() + "</b>\npoints: " + buildingPoints[currentSelected];
        }
    }
}
