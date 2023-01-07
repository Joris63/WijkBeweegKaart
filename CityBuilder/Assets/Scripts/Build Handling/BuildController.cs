using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static DataController;

public class BuildController : MonoBehaviour
{
    [SerializeField] private int buildingSizeMultiplier = 1;
    [SerializeField] private float rotateAmount = 0.2f;
    [SerializeField] private Transform buildableRegions;
    [SerializeField] private Color invalidPlacementColor = Color.red;
    [SerializeField] private Color selectedColor = Color.yellow;
    [SerializeField] private LayerMask buildable;
    [SerializeField] private GameObject buildingObjectPrefab;

    [Space(12)]
    [SerializeField] private GameObject placementMenu;

    private DataController dataController;

    private Transform currentBuilding;
    private Image currentImage;
    private bool currentValidity = true;
    private List<Transform> createdBuildings = new List<Transform>();

    private Transform selectedBuilding;
    private Image selectedImage;

    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
    }

    private void Update()
    {
        if (!dataController) return;

        if (Input.GetMouseButtonDown(0) && !currentBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 200f) && hit.transform.parent == transform)
            {
                if (selectedBuilding) selectedImage.color = Color.white;

                selectedBuilding = hit.transform;
                selectedImage = selectedBuilding.GetChild(0).GetChild(0).GetComponent<Image>();
                selectedImage.color = selectedColor;
            }
        }
    }

    private void LateUpdate()
    {
        if (!dataController) return;

        if (currentBuilding)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 200f, buildable))
            {
                currentBuilding.position = new Vector3(hit.point.x, 0.01f, hit.point.z);

                bool placementValidity = hit.transform.parent == buildableRegions;
                currentImage.color = placementValidity ? Color.white : invalidPlacementColor;
                currentValidity = placementValidity;
            }
        }
    }

    public void StartBuilding(string imageName)
    {
        if (!currentBuilding)
        {
            if (selectedBuilding)
            {
                selectedImage.color = Color.white;
                selectedBuilding = null;
            }

            Texture2D text = LoadTexture(imageName);
            if (text == null) return;

            Sprite buildingSprite = Sprite.Create(text, new Rect(0, 0, text.width, text.height), Vector2.zero, 100f);

            currentBuilding = Instantiate(buildingObjectPrefab).transform;
            currentImage = currentBuilding.transform.GetChild(0).GetChild(0).GetComponent<Image>();
            currentImage.sprite = buildingSprite;
            currentBuilding.parent = transform;
            currentBuilding.name = imageName;
            currentBuilding.localScale *= buildingSizeMultiplier;

            placementMenu.SetActive(true);
        }
    }

    private Texture2D LoadTexture(string imageName)
    {
        string path = Application.streamingAssetsPath+"/Buildings/" + imageName + ".png";
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

    public void StopBuilding()
    {
        if (currentBuilding)
        {
            placementMenu.SetActive(false);

            currentValidity = true;
            Destroy(currentBuilding.gameObject);
            currentBuilding = null;
        }
    }

    public void PlaceBuilding()
    {
        if (currentBuilding && currentValidity)
        {
            placementMenu.SetActive(false);
            createdBuildings.Add(currentBuilding);
            currentBuilding = null;
        }
    }

    public void RotateBuilding(bool isRight)
    {
        if (currentBuilding) currentBuilding.eulerAngles += new Vector3(0, isRight ? rotateAmount : -rotateAmount, 0);
    }

    public void RemoveBuilding()
    {
        if (selectedBuilding)
        {
            createdBuildings.Remove(selectedBuilding);
            Destroy(selectedBuilding.gameObject);
            selectedBuilding = null;
        }
    }

    public void SaveBuildings()
    {
        if (dataController && createdBuildings.Count > 0)
        {
            List<PlacedBuilding> buildings = new List<PlacedBuilding>();

            foreach (Transform building in createdBuildings)
            {
                buildings.Add(new PlacedBuilding()
                {
                    name = building.name,
                    position = building.position,
                    rotation = building.eulerAngles,
                    totalPoints = 0
                });
            }

            dataController.SaveBuildings(buildings);
        }
    }
}
