using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstDoorC : MonoBehaviour
{
    // The correct code to unlock the door
    public string correctCode = "";

    // The player's input code
    public string inputCode = "";

    // The maximum number of digits in the code
    public int codeLength = 4;

    // A reference to the target game object when target come close to me will trigger
    public GameObject target;
    public GameObject me;

    // The maximum distance at which the keypad will be displayed
    public float maxDistance = 2.0f;

    void Start() {
        int digit;
        for (int j = 0;j<4;j++){
            digit = UnityEngine.Random.Range(0, 2);
            correctCode += digit;
        }
    
        

    }

    void Update()
    {
        // Check if the player has entered the correct code
        if (inputCode == correctCode)
        {
            // Open the door
            me.SetActive(false);
            // To switch to a different scene:
            SceneManager.LoadScene("question_1");
            
        }
    }

    void OnGUI()
    {
        // Calculate the distance between the player and the door
        float distance = Vector3.Distance(transform.position, target.transform.position);
        // If the player is within the maximum distance of the door, display the keypad
        if (distance <= maxDistance)
        {
            // Define the GUI box position and size relative to the screen size
            Rect boxRect = new Rect(Screen.width * 0.4f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.3f);

            // Display the numerical keypad
            GUILayout.BeginArea(boxRect);
            GUILayout.BeginVertical();

            // The keypad consists of 10 buttons numbered 0-9
            for (int i = 0; i < 2; i++)
            {
                if (i == 9) // Display the reset button
                {
                    if (GUILayout.Button("Reset"))
                    {
                        inputCode = "";
                    }
                }
                else // Display the numerical buttons
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
            }

            GUILayout.EndVertical();
            GUILayout.EndArea();

            // Display the input code box relative to the GUI box position and size
            Rect codeRect = new Rect(boxRect.x + boxRect.width * 0.1f, boxRect.y + boxRect.height * 0.5f, boxRect.width * 0.9f, boxRect.height * 0.2f);
            GUI.Box(codeRect, inputCode);
        }
    }
}
