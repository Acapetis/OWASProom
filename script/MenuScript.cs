using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button startButton;
    public Button saveButton;
    public Button loadButton;
    public Button resetButton;
    
    private SaveLoadScript saveLoadScript;

    

    private void Start()
    {
        //Debug.Log()
        startButton.onClick.AddListener(StartGame);
        saveButton.onClick.AddListener(SaveProgress);
        loadButton.onClick.AddListener(LoadProgress);
        resetButton.onClick.AddListener(ResetProgress);

        saveLoadScript = GetComponent<SaveLoadScript>();
    }

    

    




    private void StartGame()
    {
        SceneManager.LoadScene("1_OutdateComponent");
        //gameObject.SetActive(false);
    }

    private void SaveProgress()
    {
        saveLoadScript.SaveProgress();
    }

    private void LoadProgress()
    {
        saveLoadScript.LoadProgress();
    }

    private void ResetProgress()
    {
        saveLoadScript.ResetProgress();
    }
}
