using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class QuestionManager : MonoBehaviour
{
    public GameObject lessonPanel; // Reference to the UI panel for the lesson text
    public TMP_Text lessonText;
    public Button nextButton; // Reference to the "Next" button

    // The text component that displays the question
    public TMP_Text questionText;

    // The buttons that represent the multiple choice options
    public Button[] answerButtons;

    // The text components for the multiple choice options
    public TMP_Text[] answerTexts;

    // The index of the correct answer
    private int correctAnswer;

    // The color for a correct answer
    private Color correctColor = Color.green;

    // The color for an incorrect answer
    private Color incorrectColor = Color.red;

    // The function that sets up the question and the multiple choice options
    public void SetQuestion(string question, string[] answers, int correctIndex)
    {
        // Set the text of the question
        questionText.text = question;

        // Set the text of the multiple choice options
        for (int i = 0; i < answers.Length; i++)
        {
            answerTexts[i].text = answers[i];

            // Add an event listener to the button
            int index = i; // Store the index in a local variable to avoid a common mistake with closures
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }

        // Set the index of the correct answer
        correctAnswer = correctIndex;

        // Show the UI panel that displays the question and the multiple choice options
        gameObject.SetActive(true);
    }

    // The function that is called when a multiple choice option is clicked
    public void CheckAnswer(int index)
    {
        // Disable the answer buttons to prevent the player from clicking them again
        foreach (Button button in answerButtons)
        {
            button.enabled = false;
        }

        // Check if the answer is correct
        if (index == correctAnswer)
        {
            // Change the color of the button to green
            answerButtons[index].image.color = correctColor;
        }
        else
        {
            // Change the color of the button to red
            answerButtons[index].image.color = incorrectColor;
        }
        
        // Wait for a short delay to give the player a chance to see the button color change
        StartCoroutine(DelayedAction(() => {
            // Replace the question and answer text with the new lesson
            questionText.text = "Outdated Component: Using outdated components in a computer system can be a major security risk, as it can leave the system vulnerable to known security exploits. The most common risk associated with using an outdated component is the lack of security updates, which can leave the system open to attacks that have already been patched in more recent versions of the component.";
            lessonPanel.SetActive(true);
            // Hide the answer buttons
            foreach (Button button in answerButtons)
            {
                button.gameObject.SetActive(false);
            }
        }, 1f));

        nextButton.gameObject.SetActive(true);
    }

    // A coroutine that waits for a delay and then executes an action
    private IEnumerator DelayedAction(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }


    public void Start()
    {
        string[] answers = {"A.Information leakage", "B.Lack of security updates", "C.Insecure data storage", "D.Inefficient processing"};
        SetQuestion("What is the most common security risk of using an outdated component in a computer system?", answers, 1);
    }

    public void LoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene("2_Identification");
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            LoadNextScene();
        }
    }
}
