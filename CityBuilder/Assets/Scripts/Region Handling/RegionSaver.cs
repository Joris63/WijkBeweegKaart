using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegionSaver : MonoBehaviour
{
    public static RegionSaver main { get; private set; }

    [HideInInspector] public List<Vector3[]> savedRegions = new List<Vector3[]>();

    private void Awake()
    {
        if (main) Destroy(gameObject);
        else
        {
            main = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name != "AdminScene")
        {
            main = null;
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            LoadScene("AdminScene");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
