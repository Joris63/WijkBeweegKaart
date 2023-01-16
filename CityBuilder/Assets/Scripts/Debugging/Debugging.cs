using UnityEngine;
using UnityEngine.SceneManagement;

public class Debugging : MonoBehaviour
{
    [SerializeField] private KeyCode keyToPress;
    [SerializeField] private string sceneToLoad;

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
