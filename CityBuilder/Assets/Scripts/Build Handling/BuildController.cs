using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] private Transform buildableRegions;
    [SerializeField] private Color invalidPlacementColor = Color.red;

    private Transform currentBuilding;
    private List<(Renderer, Color)> buildingRenderers = new List<(Renderer, Color)>();
    private bool currentValidity = true;

    private void Update()
    {
        if (currentBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Get mouse position in world space
                Vector3 rayPoint = ray.GetPoint(hit.distance);
                rayPoint.y = 0f;

                currentBuilding.position = rayPoint;

                bool placementValidity = hit.transform.parent == buildableRegions;
                if ((placementValidity && !currentValidity) || (!placementValidity && currentValidity))
                {
                    foreach ((Renderer, Color) data in buildingRenderers)
                    {
                        data.Item1.material.color = placementValidity ? data.Item2 : invalidPlacementColor;
                    }
                }
                currentValidity = placementValidity;

                if (Input.GetMouseButtonDown(0) && currentValidity)
                {
                    buildingRenderers.Clear();
                    currentBuilding = null;
                }
            }
        }
    }

    public void StartBuilding(GameObject buildingPrefab)
    {
        if (!currentBuilding)
        {
            currentBuilding = Instantiate(buildingPrefab).transform;

            foreach (Renderer renderer in currentBuilding.GetComponentsInChildren<Renderer>())
            {
                buildingRenderers.Add((renderer, renderer.material.color));
            }
        }
    }
}
