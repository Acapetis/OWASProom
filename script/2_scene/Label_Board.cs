using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OnTriggerNameSpace;


public class Label_Board : MonoBehaviour
{
    private string phrase; // The phrase to display
    private OnTrigger onTrigger;
    public TMP_Text displayText;
    private bool playerInRange = false;

    void Start()
    {
        displayText.text = phrase;
    }



    public void SetPhrase(string newPhrase)
    {
        phrase = newPhrase;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            displayText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            displayText.gameObject.SetActive(true);
            //displayText.SetActive(true);
            displayText.text = phrase;
            Debug.Log("in range");
        }
        
    }
}
