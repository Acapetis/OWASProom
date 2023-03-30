using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPad : MonoBehaviour
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

    void OnGUI()
    {
        // Display the numerical keypad
        GUILayout.BeginArea(new Rect(10, 10, 100, 300));
        GUILayout.BeginVertical();

        // The keypad consists of 10 buttons numbered 0-9
        for (int i = 0; i < 10; i++)
        {
            if (GUILayout.Button(i.ToString()))
            {
                // When a button is pressed, append the number to the input code
                inputCode += i.ToString();

                // If the input code is too long, truncate it to the maximum code length
                if (inputCode.Length > codeLength)
                {
                    inputCode = inputCode.Substring(0, codeLength);
                }
            }
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
