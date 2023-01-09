using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

    DataController dataController;

    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
        if (dataController) dataController.onDataRetrieved.AddListener(OnDataRetrieved);
    }

    private void OnDataRetrieved()
    {
        dataController.onDataRetrieved.RemoveListener(OnDataRetrieved);

        switch (dataController.Mode)
        {
            case "Admin":
                SceneManager.LoadScene("AdminScene");
                break;
            case "Build":
                SceneManager.LoadScene("BuildingScene");
                break;
            case "Rate":
                SceneManager.LoadScene("RatingScene");
                break;
            default:
                loadingText.text = "something went wrong.";
                break;
        }
    }
}
