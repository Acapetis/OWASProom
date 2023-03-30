using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoadScript : MonoBehaviour
{
    public int currentStage;

    public string[] sceneNames;

    bool isMenuActive;

    public GameObject menuObject;


    private void Start()
    {
        if (PlayerPrefs.HasKey("stage"))
        {
            currentStage = PlayerPrefs.GetInt("stage");
        }
        else
        {
            currentStage = 1;
        }
    }

    void Update() 
    {
        
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("on");
            isMenuActive = !isMenuActive;
            menuObject.SetActive(!menuObject.activeSelf);
        }
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetString("currentScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }


    public void LoadProgress()
    {
        string currentScene = PlayerPrefs.GetString("currentScene", "0_Menu");
        SceneManager.LoadScene(currentScene);
    }


    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        currentStage = 1;
    }
}
