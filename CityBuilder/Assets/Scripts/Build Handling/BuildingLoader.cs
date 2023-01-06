using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static DataController;

public class BuildingLoader : MonoBehaviour
{
    [SerializeField] private GameObject buildingObjectPrefab;

    DataController dataController;

    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
        if (dataController) dataController.onDataRetrieved.AddListener(OnDataRetrieved);

        // Debugging
#if UNITY_EDITOR
        OnDataRetrieved();
#endif
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
}
