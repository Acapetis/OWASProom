using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pass_door : MonoBehaviour
{
    // The correct code to unlock the door
    public string correctCode = "1234";

    // The player's input code
    public string inputCode = "";

    // The maximum number of digits in the code
    public int codeLength = 4;

    // A reference to the door game object
    public GameObject target;
    public GameObject me;

    // The maximum distance at which the keypad will be displayed
    public float maxDistance = 2.0f;

    void Update()
    {
        // Check if the player has entered the correct code
        if (inputCode == correctCode)
        {
            // Open the door
            me.SetActive(false);
            // To switch to a different scene:
            SceneManager.LoadScene("3_Integrity");
            
        }
    }

    void OnGUI()
    {
        // Calculate the distance between the player and the door
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(distance);
        // If the player is within the maximum distance of the door, display the keypad
        if (distance <= maxDistance)
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
                        inputCode = "";
                    }
                }
            }

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
        GUI.Box(new Rect(410, 70, 200, 20), inputCode);
    }
}
