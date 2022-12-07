using System.Collections.Generic;
using UnityEngine;

public class RegionCreator : MonoBehaviour
{
    [Min(0.1f)]
    [SerializeField] private float snapDistance = 0.5f;
    [SerializeField] private Color closingColor = Color.white;

    [Space(12)]
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject linePrefab;

    private PolygonTriangulator polygonTriangulator;
    private Plane raycastPlane;
    private Color defaultColor;

    private Transform pointBlueprint = null;
    private Transform lineBlueprint = null;
    private Vector3 currentOrigin = Vector3.zero;

    private List<Vector3> createdVertices = new List<Vector3>();
    private List<Renderer> createdRenderers = new List<Renderer>();

    private bool isSnapping = false;
    private bool isTriangulating = false;

    private void Awake()
    {
        polygonTriangulator = FindObjectOfType<PolygonTriangulator>();
        if (!polygonTriangulator) Debug.LogWarning("No Polygon Triangulator present in scene.");
        raycastPlane = new Plane(Vector3.up, 0);
        defaultColor = pointPrefab.GetComponent<Renderer>().sharedMaterial.color;
    }

    private void Update()
    {
        if (!polygonTriangulator) return;

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
                        renderer.material.color = isSnapping ? closingColor : defaultColor;
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
                    bool success = polygonTriangulator.CreateTriangles(vertices, out int[] triangles);

                    // Create plane
                    if (success)
                    {
                        if (RegionSaver.main) RegionSaver.main.savedRegions.Add(vertices);
                        polygonTriangulator.CreatePlane(vertices, triangles);
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
}
