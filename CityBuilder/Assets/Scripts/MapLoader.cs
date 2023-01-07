using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Data;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private bool addColliders = false;

    private AbstractMap map;

    private void Start()
    {
        map = GetComponent<AbstractMap>();
        map.Initialize(new Mapbox.Utils.Vector2d(51.450548, 5.4566345), 16);
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
