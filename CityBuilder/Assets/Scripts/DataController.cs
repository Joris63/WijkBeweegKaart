using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class DataController : MonoBehaviour
{
    public class AvailableBuilding
    {
        public string name;
        public string imageName;
    }

    public class PlacedBuilding
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;
        public int totalPoints;
    }

    public UnityEvent onDataRetrieved;

    // ---------- DTOs ----------
    private class RegionDTO { public List<Vector3[]> regions; }
    private class BuildingDTO { public List<PlacedBuilding> buildings; }

    // ---------- DATA ----------
    private string mode;
    public string Mode { get { return mode; } }

    private List<AvailableBuilding> availableBuildings = new List<AvailableBuilding>();
    public List<AvailableBuilding> AvailableBuildings { get { return availableBuildings; } }

    private List<Vector3[]> savedRegions = new List<Vector3[]>();
    public List<Vector3[]> SavedRegions { get { return savedRegions; } }

    private List<PlacedBuilding> savedBuildings = new List<PlacedBuilding>();
    public List<PlacedBuilding> SavedBuildings { get { return savedBuildings; } }

    // ---------- LOGIC ----------
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        UnityInitialized();
#endif
    }

    public void InitializeData(string mode, string regions, string placedBuildings, List<AvailableBuilding> availableBuildings)
    {
        if (!string.IsNullOrEmpty(mode)) this.mode = mode;
        if (!string.IsNullOrEmpty(regions)) savedRegions = JsonUtility.FromJson<RegionDTO>(regions).regions;
        if (!string.IsNullOrEmpty(placedBuildings)) savedBuildings = JsonUtility.FromJson<BuildingDTO>(placedBuildings).buildings;
        if (availableBuildings != null) this.availableBuildings = availableBuildings;

        onDataRetrieved.Invoke();
    }

    public void SaveRegions(List<Vector3[]> regions)
    {
        string data = JsonUtility.ToJson(new RegionDTO() { regions = regions });
#if UNITY_WEBGL && !UNITY_EDITOR
        SendRegionsData(data);
#endif

        // Debugging
#if UNITY_EDITOR
        savedRegions = regions;
#endif
    }

    public void SaveBuildings(List<PlacedBuilding> buildings)
    {
        string data = JsonUtility.ToJson(new BuildingDTO() { buildings = buildings });
#if UNITY_WEBGL && !UNITY_EDITOR
        SendBuildingsData(data);
#endif

        // Debugging
#if UNITY_EDITOR
        savedBuildings = buildings;
#endif
    }

    [DllImport("__Internal")]
    private static extern void UnityInitialized();
    [DllImport("__Internal")]
    private static extern void SendRegionsData(string data);
    [DllImport("__Internal")]
    private static extern void SendBuildingsData(string data);
}
