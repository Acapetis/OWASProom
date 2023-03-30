using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    // The correct code to unlock the door
    public string correctCode = "1234";

    // The player's input code
    public string inputCode = "";

    // The maximum number of digits in the code
    public int codeLength = 4;

    // A reference to the door game object
    public GameObject door;

    void Update()
    {
        // Check if the player has entered the correct code
        if (inputCode == correctCode)
        {
            // Open the door
            door.SetActive(false);
        }
    }
}
