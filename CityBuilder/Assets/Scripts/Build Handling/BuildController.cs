using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] private Transform buildableRegions;
    [SerializeField] private Color invalidPlacementColor = Color.red;

    private Transform currentBuilding;
    private List<(Renderer, Color)> buildingRenderers = new List<(Renderer, Color)>();
    private bool currentValidity = true;



    private void LateUpdate()
    {
        if (currentBuilding)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
            {
                currentBuilding.position = hit.point;

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

    public void RotateBuilding(bool isRight)
    {
        Quaternion rotation = currentBuilding.transform.rotation;
        if (isRight)
        {
            currentBuilding.eulerAngles += new Vector3(0, 22.5f, 0);
        }

        if (!isRight)
        {
            currentBuilding.eulerAngles += new Vector3(0, -22.5f, 0);
        }
    }
}
