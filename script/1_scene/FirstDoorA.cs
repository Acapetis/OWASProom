using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstDoorA : MonoBehaviour
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
        int firstDigit;
        for (int i = 0; i<codeLength; i++){
            firstDigit = UnityEngine.Random.Range(0, 2);
            correctCode += firstDigit.ToString();
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
            SceneManager.LoadScene("lesson_1");
            
        }
    }

    
   
    void OnGUI()
    {
        // Calculate the distance between the player and the door
        float distance = Vector3.Distance(transform.position, target.transform.position);

        // If the player is within the maximum distance of the door, display the keypad
        if (distance <= maxDistance)
        {
            // Define custom GUIStyle for the buttons
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 60;

            // Define custom GUIStyle for the input box
            GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.fontSize = 40;

            // Calculate the position and size of the keypad area
            float keypadX = Screen.width / 2 - 110;
            float keypadY = Screen.height / 2 - 200;
            float keypadWidth = 220;
            float keypadHeight = 300;

            // Draw the keypad area
            GUI.Box(new Rect(keypadX, keypadY, keypadWidth, keypadHeight), "");

            // Calculate the position and size of each button
            float buttonWidth = 200;
            float buttonHeight = 80;
            float buttonPadding = 10;
            float buttonX = keypadX + buttonPadding;
            float buttonY = keypadY + buttonPadding;

            // Draw each button
            for (int i = 0; i < 2; i++)
            {
                if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), i.ToString(), buttonStyle))
                {
                    // When a button is pressed, append the number to the input code
                    inputCode += i.ToString();

                    // If the input code is too long, truncate it to the maximum code length
                    if (inputCode.Length > codeLength)
                    {
                        inputCode = "";
                    }
                }

                // Move to the next button position
                buttonY += buttonHeight + buttonPadding;
            }

            // Draw the reset button
            if (GUI.Button(new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "Reset", buttonStyle))
            {
                inputCode = "";
            }

            // Draw the input box
            float boxX = Screen.width / 2 - 150;
            float boxY = Screen.height / 2 + 180;
            float boxWidth = 300;
            float boxHeight = 80;

            GUI.Box(new Rect(boxX, boxY, boxWidth, boxHeight), inputCode, boxStyle);
        }
    }







}
