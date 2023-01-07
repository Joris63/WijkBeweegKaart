using UnityEngine;

[RequireComponent(typeof(PolygonTriangulator))]
public class RegionLoader : MonoBehaviour
{
    PolygonTriangulator polygonTriangulator;
    DataController dataController;

    private void Awake()
    {
        polygonTriangulator = GetComponent<PolygonTriangulator>();
        dataController = FindObjectOfType<DataController>();
        if (dataController) OnDataRetrieved();
    }

    private void OnDataRetrieved()
    {
        foreach (Vector3[] vertices in dataController.SavedRegions)
        {
            bool success = polygonTriangulator.CreateTriangles(vertices, out int[] triangles);

            if (success)
            {
                GameObject plane = polygonTriangulator.CreatePlane(vertices, triangles);
                plane.layer = LayerMask.NameToLayer("Buildable");
                plane.transform.parent = transform;
            }
        }
    }
}
