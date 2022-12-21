using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] private float rotateAmount = 22.5f;
    [SerializeField] private Transform buildableRegions;
    [SerializeField] private Color invalidPlacementColor = Color.red;

    private Transform currentBuilding;
    private List<(Renderer, Color)> buildingRenderers = new List<(Renderer, Color)>();
    private bool currentValidity = true;

    private HUDInitializer hudInitializer;

    private void Awake()
    {
        hudInitializer = FindObjectOfType<HUDInitializer>();
    }

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
            }
        }
    }

    public void StartBuilding(string prefabName)
    {
        if (!currentBuilding)
        {
            GameObject buildingPrefab = Resources.Load<GameObject>("Buildings/"+prefabName);
            if (!buildingPrefab) return;
            currentBuilding = Instantiate(buildingPrefab).transform;

            foreach (Renderer renderer in currentBuilding.GetComponentsInChildren<Renderer>())
            {
                buildingRenderers.Add((renderer, renderer.material.color));
            }

            hudInitializer.SetMenueActive(true);
        }
    }

    public void StopBuilding()
    {
        hudInitializer.SetMenueActive(false);
        buildingRenderers.Clear();
        currentValidity = true;
        Destroy(currentBuilding.gameObject);
        currentBuilding = null;
    }

    public void PlaceBuilding()
    {
        if (currentValidity)
        {
            hudInitializer.SetMenueActive(false);
            buildingRenderers.Clear();
            currentBuilding = null;
        }
    }

    public void RotateBuilding(bool isRight)
    {
        currentBuilding.eulerAngles += new Vector3(0, isRight ? rotateAmount : -rotateAmount, 0);
    }
}
