using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Data;
using UnityEngine;

[RequireComponent(typeof(AbstractMap))]
public class MapLoader : MonoBehaviour
{
    [SerializeField] private bool addColliders = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        DataController dataController = FindObjectOfType<DataController>();
        if (dataController) InitializeMap();
    }

    public void InitializeMap(double latitude = 51.450548, double longitude = 5.4566345)
    {
        AbstractMap map = GetComponent<AbstractMap>();
        map.Initialize(new Mapbox.Utils.Vector2d(latitude, longitude), 16);
        if (addColliders) map.Terrain.EnableCollider(true);

        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<UnityTile>())
            {
                child.layer = LayerMask.NameToLayer("Buildable");
            }
        }
    }
}
