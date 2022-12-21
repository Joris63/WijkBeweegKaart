using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public class Building
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;
        public int totalPoints;
    }

    private class RegionDTO { public List<Vector3[]> regions; }
    private class BuildingDTO { public List<Building> buildings; }

    private List<Vector3[]> savedRegions = new List<Vector3[]>();
    [HideInInspector] public List<Vector3[]> SavedRegions { get { return savedRegions; } }

    private List<Building> savedBuildings = new List<Building>();
    [HideInInspector] public List<Building> SavedBuildings { get { return savedBuildings; } }

    public void InitializeData(string regions, string buildings)
    {
        if (!string.IsNullOrEmpty(regions)) savedRegions = JsonUtility.FromJson<RegionDTO>(regions).regions;
        if (!string.IsNullOrEmpty(buildings)) savedBuildings = JsonUtility.FromJson<BuildingDTO>(buildings).buildings;
    }

    public void SaveRegions(List<Vector3[]> regions)
    {
        string data = JsonUtility.ToJson(new RegionDTO() { regions = regions });
#if UNITY_WEBGL && !UNITY_EDITOR
        SendRegionsData(data);
#endif

        // Mock
#if UNITY_EDITOR
        savedRegions = regions;
#endif
    }

    public void SaveBuildings(List<Building> buildings)
    {
        string data = JsonUtility.ToJson(new BuildingDTO() { buildings = buildings });
#if UNITY_WEBGL && !UNITY_EDITOR
        SendBuildingsData(data);
#endif

        // Mock
#if UNITY_EDITOR
        savedBuildings = buildings;
#endif
    }

    [DllImport("__Internal")]
    private static extern void SendRegionsData(string data);
    [DllImport("__Internal")]
    private static extern void SendBuildingsData(string data);
}
