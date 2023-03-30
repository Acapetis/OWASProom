using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelBoard : MonoBehaviour
{
    public string[] phrases; // An array of phrases to display

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        if (other.gameObject.tag == "Player")
        {
            // Display the phrases
            for (int i = 0; i < phrases.Length; i++)
            {
                GUI.Label(new Rect(10, 10 + (i * 20), 100, 20), phrases[i]);
            }
        }
    }
}

