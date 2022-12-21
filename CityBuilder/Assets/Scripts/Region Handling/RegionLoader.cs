using UnityEngine;

public class RegionLoader : MonoBehaviour
{
    private void Start()
    {
        PolygonTriangulator polygonTriangulator = FindObjectOfType<PolygonTriangulator>();

        /*
        if (DataController.main && polygonTriangulator)
        {
            foreach (Vector3[] vertices in DataController.main.savedRegions)
            {
                bool success = polygonTriangulator.CreateTriangles(vertices, out int[] triangles);

                if (success)
                {
                    GameObject plane = polygonTriangulator.CreatePlane(vertices, triangles);
                    plane.transform.parent = transform;
                }
            }
        }
        */
    }
}
