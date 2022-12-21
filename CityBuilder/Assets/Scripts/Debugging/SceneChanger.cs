using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private KeyCode keyToPress;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private List<GameObject> dontDestroyObjects = new List<GameObject>();
    private bool isLoading = false;

    private void Awake()
    {
        foreach(GameObject go in dontDestroyObjects)
        {
            DontDestroyOnLoad(go);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress) && !isLoading)
        {
            isLoading = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
#endif
}
