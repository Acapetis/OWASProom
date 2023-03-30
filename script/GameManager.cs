using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject menu;


    void Start()
    {
        //menu = GameObject.Find("menu");

    }

    void Pause(){
        menu.SetActive(true);
        GameIsPause = true;
    }

    void Resume(){
        menu.SetActive(false);
        GameIsPause = false;
    }
    

    // Update is called once per frame
    void Update() {
        
        if(Input.GetKeyUp(KeyCode.Escape)) {
            if(GameIsPause){
                Resume();
            }
            else{
                Pause();
            }
            
            
        }
    }


}
