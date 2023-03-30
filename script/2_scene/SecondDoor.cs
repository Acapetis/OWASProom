using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SecondDoor : MonoBehaviour
{
    public PasswordGenerator passwordGenerator;
    public TMP_InputField inputField;
    public string correctCode;
    public float maxDistance;
    public int codeLength;
    public GameObject target;
    private List<string> passwords;
    private string inputCode;

    void Start()
    {
        passwords = passwordGenerator.selectedPasswords2;
        correctCode = passwords[Random.Range(0, passwords.Count)];
        Debug.Log("Correct code: " + correctCode);
        codeLength = correctCode.Length;

        // Set the focus to the input field so the player can start typing immediately
        inputField.Select();
    }

    public void CheckCode()
    {
        string inputCode = inputField.text;

        if (inputCode.Length > correctCode.Length)
        {
            inputCode = inputCode.Substring(0, correctCode.Length);
        }

        if (inputCode == correctCode)
        {
            Debug.Log("Correct code entered!");
            // Open door
            SceneManager.LoadScene("lesson_2");
        }
        else
        {
            Debug.Log("Incorrect code entered!");
            // Reset the input field
            inputField.text = "";
        }
    }


    void Update()
    {
        // Detect keyboard input and update the input code accordingly
        if (Input.anyKeyDown)
        {
            CheckCode();
            string keyPressed = Input.inputString;
            if (keyPressed.Length == 1 && char.IsLetterOrDigit(keyPressed[0]))
            {
                inputCode += keyPressed;

                // If the input code is too long, truncate it to the maximum code length
                if (inputCode.Length > codeLength)
                {
                    inputCode = inputCode.Substring(0, codeLength);
                }

                // Update the input field text
                inputField.text = inputCode;
            }
        }

        
    }

    void OnGUI(){
        GUILayout.BeginArea(new Rect(1000, 800, 100, 300));
        GUILayout.BeginVertical();
        if (GUILayout.Button("Reset"))
        {
            inputCode = "";
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
