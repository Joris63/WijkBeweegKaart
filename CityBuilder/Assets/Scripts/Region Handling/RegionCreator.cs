using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PolygonTriangulator))]
public class RegionCreator : MonoBehaviour
{
    [Min(0.1f)]
    [SerializeField] private float snapDistance = 0.5f;
    [SerializeField] private Color closingColor = Color.white;

    [Space(12)]
    [SerializeField] private Color selectedColor = Color.white;

    [Space(12)]
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject linePrefab;

    private PolygonTriangulator polygonTriangulator;
    private DataController dataController;
    private EventSystem eventSystem;
    private Color defaultEdgeColor;

    private Transform pointBlueprint = null;
    private Transform lineBlueprint = null;
    private Vector3 currentOrigin = Vector3.zero;

    private Renderer selectedRegion = null;
    private Color defaultRegionColor;

    private List<Vector3> createdVertices = new List<Vector3>();
    private List<Renderer> createdRenderers = new List<Renderer>();
    private Dictionary<Renderer, Vector3[]> createdRegions = new Dictionary<Renderer, Vector3[]>();

    private bool isSnapping = false;
    private bool isTriangulating = false;

    private void Awake()
    {
        polygonTriangulator = GetComponent<PolygonTriangulator>();
        dataController = FindObjectOfType<DataController>();
        if (!dataController) Debug.LogWarning("No Data Controller present in scene.");
        eventSystem = FindObjectOfType<EventSystem>();
        defaultEdgeColor = pointPrefab.GetComponent<Renderer>().sharedMaterial.color;
    }

    private void Update()
    {
        if (!dataController) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f))
        {
            // If user has selected a region and is not placing vertices
            if (Input.GetMouseButtonDown(0) && !eventSystem.IsPointerOverGameObject() && hit.transform.parent == transform && !pointBlueprint && !lineBlueprint)
            {
                if (selectedRegion) selectedRegion.material.color = defaultRegionColor;

                selectedRegion = hit.transform.GetComponent<Renderer>();
                defaultRegionColor = selectedRegion.material.color;
                selectedRegion.material.color = selectedColor;
            }
            // Place vertices
            else
            {
                // Get mouse position in world space
                Vector3 rayPoint = hit.point;
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
                            renderer.material.color = isSnapping ? closingColor : defaultEdgeColor;
                        }
                    }

                    if (isSnapping) rayPoint = createdVertices[0];
                }

                // Place new vertice
                if (Input.GetMouseButtonDown(0) && !eventSystem.IsPointerOverGameObject())
                {
                    // Unselect selected region if it exists
                    if (selectedRegion)
                    {
                        selectedRegion.material.color = defaultRegionColor;
                        selectedRegion = null;
                    }

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
                        // Create triangles
                        Vector3[] vertices = createdVertices.ToArray();
                        bool success = polygonTriangulator.CreateTriangles(vertices, out int[] triangles);

                        // Create plane
                        if (success)
                        {
                            Renderer plane = polygonTriangulator.CreatePlane(vertices, triangles).GetComponent<Renderer>();
                            plane.transform.parent = transform;
                            createdRegions.Add(plane, vertices);
                        }

                        CancelPlacement();
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

    private void CancelPlacement()
    {
        Destroy(pointBlueprint.gameObject);
        Destroy(lineBlueprint.gameObject);

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

    public void RemoveRegion()
    {
        // If user is placing vertices
        if (pointBlueprint && lineBlueprint)
        {
            CancelPlacement();
        }
        // If user has selected a region
        else if (selectedRegion)
        {
            createdRegions.Remove(selectedRegion);
            Destroy(selectedRegion.gameObject);
            selectedRegion = null;
        }
    }

    public void SaveRegions()
    {
        if (dataController && createdRegions.Count > 0)
        {
            List<Vector3[]> regions = new List<Vector3[]>();

            foreach (KeyValuePair<Renderer, Vector3[]> region in createdRegions)
            {
                regions.Add(region.Value);
            }

            dataController.SaveRegions(regions);
        }
    }
}
