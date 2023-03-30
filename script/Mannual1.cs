using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class Mannual1 : MonoBehaviour
{
    public GameObject MannualPanel; // Reference to the UI panel for the lesson text
    public TMP_Text MannualText;

    public void SetMannual(string mannual){
        gameObject.SetActive(true);
        MannualText.text = mannual;
    }
    
    
    public void Start()
    {
        //SetMannual("In this room, the player is tasked with finding the non-updated door to pass through. This room refers to the OWASP concept of Outdated Components. An outdated component can lead to a number of vulnerabilities, including known security vulnerabilities that can be easily exploited. In order to reduce the risk of vulnerabilities, it is important to keep all components up-to-date and replace any outdated components with newer, more secure versions");
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
        Debug.Log("click");
    }
    
}