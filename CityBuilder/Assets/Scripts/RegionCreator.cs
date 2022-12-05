using System.Collections.Generic;
using UnityEngine;

public class RegionCreator : MonoBehaviour
{
    [Range(4, 256)]
    [SerializeField] private int maxVertices = 32;
    [Min(0.1f)]
    [SerializeField] private float snapDistance = 0.5f;
    [SerializeField] private Material regionMaterial;

    [Space(12)]
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject linePrefab;

    private Plane raycastPlane;

    private Transform pointBlueprint = null;
    private Transform lineBlueprint = null;
    private Vector3 currentOrigin = Vector3.zero;

    private List<Vector3> createdVertices = new List<Vector3>();
    private List<Renderer> createdRenderers = new List<Renderer>();

    private bool isSnapping = false;
    private bool isTriangulating = false;

    private void Awake()
    {
        raycastPlane = new Plane(Vector3.up, 0);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (raycastPlane.Raycast(ray, out float rayDistance))
        {
            // Get mouse position in world space
            Vector3 rayPoint = ray.GetPoint(rayDistance);
            rayPoint.y = 0f;

            // Polygon must contain at least 3 vertices (triangle)
            if (createdVertices.Count >= 3 && pointBlueprint)
            {
                // Get distance between mouse world position and first vertice
                float distance = (createdVertices[0] - rayPoint).magnitude;

                if ((distance <= snapDistance && !isSnapping) || (distance > snapDistance && isSnapping))
                {
                    isSnapping = distance <= snapDistance;

                    foreach (Renderer renderer in createdRenderers)
                    {
                        renderer.material.color = isSnapping ? Color.white : Color.black;
                    }
                }

                if (isSnapping) rayPoint = createdVertices[0];
            }

            // Place new vertice
            if (Input.GetMouseButtonDown(0))
            {
                // Set new origin
                currentOrigin = rayPoint;

                // Create point and line blueprint if they do not exist yet
                if (!pointBlueprint && !lineBlueprint && !isTriangulating)
                {
                    isTriangulating = true;
                    pointBlueprint = Instantiate(pointPrefab, currentOrigin, Quaternion.identity, transform).transform;
                    createdRenderers.Add(pointBlueprint.GetComponent<Renderer>());
                    lineBlueprint = Instantiate(linePrefab, currentOrigin, Quaternion.identity, transform).transform;
                    createdRenderers.Add(lineBlueprint.GetComponent<Renderer>());
                }
                // Create line on line blueprint position
                else if (lineBlueprint)
                {
                    GameObject newLine = Instantiate(linePrefab, lineBlueprint.position, lineBlueprint.rotation, transform);
                    newLine.transform.localScale = lineBlueprint.localScale;
                    createdRenderers.Add(newLine.GetComponent<Renderer>());
                }

                // Polygon is closed and shape is created, disable placement
                if (isSnapping && pointBlueprint)
                {
                    Destroy(pointBlueprint.gameObject);
                    Destroy(lineBlueprint.gameObject);

                    // Create triangles
                    Vector3[] vertices = createdVertices.ToArray();
                    bool success = CreateTriangles(vertices, out int[] triangles);

                    // Create plane
                    if (success)
                    {
                        GameObject plane = new GameObject("Plane");
                        MeshFilter meshFilter = plane.AddComponent<MeshFilter>();
                        plane.AddComponent<MeshRenderer>().materials[0] = regionMaterial;

                        Mesh mesh = new Mesh()
                        {
                            vertices = vertices,
                            triangles = triangles
                        };

                        meshFilter.mesh = mesh;
                        mesh.RecalculateBounds();
                        mesh.RecalculateNormals();
                    }

                    // Destroy points and lines
                    foreach (Renderer renderer in createdRenderers)
                    {
                        Destroy(renderer.gameObject);
                    }

                    // Clear vertices and renderers
                    createdVertices.Clear();
                    createdRenderers.Clear();

                    isSnapping = false;
                    isTriangulating = false;
                }
                // Create point at new origin
                else if (pointBlueprint)
                {
                    // Add point and renderer
                    GameObject newPoint = Instantiate(pointPrefab, currentOrigin, Quaternion.identity, transform);
                    createdRenderers.Add(newPoint.GetComponent<Renderer>());

                    // Add new vertice
                    createdVertices.Add(currentOrigin);
                }
            }

            // Update point and line blueprints
            if (pointBlueprint && lineBlueprint)
            {
                // Set point
                pointBlueprint.position = rayPoint;

                // Set line
                lineBlueprint.position = Vector3.Lerp(currentOrigin, rayPoint, 0.5f);
                lineBlueprint.LookAt(rayPoint);
                lineBlueprint.Rotate(90, 0, 0, Space.Self);
                lineBlueprint.localScale = new Vector3(lineBlueprint.localScale.x, (currentOrigin - rayPoint).magnitude / 2f, lineBlueprint.localScale.z);
            }
        }
    }

    private bool CreateTriangles(Vector3[] vertices, out int[] triangles)
    {
        triangles = null;

        if (vertices.Length < 3) { Debug.LogWarning("Polygon must contain at least 3 vertices."); return false; }
        else if (vertices.Length > maxVertices) { Debug.LogWarning("Polygon contains too many vertices, maximum vertices is set to" + maxVertices + "."); return false; }

        // Create a list of numbers, referencing a vertice
        List<int> indexList = new List<int>();
        for (int i = 0; i < vertices.Length; i++)
        {
            indexList.Add(i);
        }

        triangles = new int[(vertices.Length - 2) * 3] ;
        int triangleIndexCount = 0;

        // While the end shape is not a triangle, continue triangulating
        while (indexList.Count > 3)
        {
            for (int i = 0; i < indexList.Count; i++)
            {
                // Get the current vertice and its connected vertices
                int a = indexList[i];
                int b = GetVertice(indexList, i - 1);
                int c = GetVertice(indexList, i + 1);

                // Is the vertice a convex or concave?
                if (Cross(vertices[b] - vertices[a], vertices[c] - vertices[a]) < 0)
                {
                    // Is the last vertice of the polygon being checked
                    if (i == indexList.Count - 1)
                    {
                        // Polygon is possibly counterclockwise
                        Debug.LogError("Cannot create triangles, polygon is possibly counterclockwise.");
                        return false;
                    }

                    // Vertice is a concave
                    continue;
                }

                bool isEar = true;

                // Does the triangle formed from a, b & c contain any other vertices in it
                for (int j = 0; j < vertices.Length; j++)
                {
                    if (j  == a || j == b || j == c)
                    {
                        continue;
                    }

                    if (IsPointInTriangle(vertices[j], vertices[b], vertices[a], vertices[c]))
                    {
                        isEar = false;
                        break;
                    }
                }

                if (isEar)
                {
                    triangles[triangleIndexCount++] = b;
                    triangles[triangleIndexCount++] = a;
                    triangles[triangleIndexCount++] = c;

#if UNITY_EDITOR
                    // Debugging
                    Debug.DrawLine(new Vector3(vertices[b].x, 0, vertices[b].z), new Vector3(vertices[c].x, 0, vertices[c].z), Color.black, 10f);
#endif

                    indexList.RemoveAt(i);
                    break;
                }
                // Is the last vertice of the polygon being checked
                else if (!isEar && i == indexList.Count - 1)
                {
                    // Something unknown went wrong
                    Debug.LogError("Something went wrong while trying to create triangles.");
                    return false;
                }
            }
        }

        triangles[triangleIndexCount++] = indexList[0];
        triangles[triangleIndexCount++] = indexList[1];
        triangles[triangleIndexCount++] = indexList[2];

        return true;
    }

    private float Cross(Vector3 a, Vector3 b)
    {
        return a.x * b.z - a.z * b.x;
    }

    private int GetVertice(List<int> list, int index)
    {
        if (index >= list.Count)
        {
            return list[index % list.Count];
        }
        else if (index < 0)
        {
            return list[index % list.Count + list.Count];
        }
        else
        {
            return list[index];
        }
    }

    private bool IsPointInTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
        if (Cross(b - a, p - a) > 0f || Cross(c - b, p - b) > 0f || Cross(a - c, p - c) > 0f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
