using System.Collections.Generic;
using UnityEngine;

public class PolygonTriangulator : MonoBehaviour
{
    [Range(4, 256)]
    [SerializeField] private int maxVertices = 32;
    [SerializeField] private Material planeMaterial;

    public GameObject CreatePlane(Vector3[] vertices, int[] triangles)
    {
        GameObject plane = new GameObject("Plane");
        MeshFilter meshFilter = plane.AddComponent<MeshFilter>();
        MeshCollider meshCollider = plane.AddComponent<MeshCollider>();
        plane.AddComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(planeMaterial);

        Mesh mesh = new Mesh()
        {
            vertices = vertices,
            triangles = triangles
        };

        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return plane;
    }

    public bool CreateTriangles(Vector3[] vertices, out int[] triangles)
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

        triangles = new int[(vertices.Length - 2) * 3];
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
                    if (j == a || j == b || j == c)
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
