using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 10f; // Initial time remaining in seconds
    private bool timerRunning = true; // Flag to track whether the timer is running

    void StartTimer()
    {
        timeRemaining = 10f; // Reset the time remaining to the initial value
        timerRunning = true; // Set the timerRunning flag to true
    }

    void StopTimer()
    {
        timerRunning = false; // Set the timerRunning flag to false
    }

    void Update()
    {
        if (timerRunning) // Check if the timer is running
        {
            GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(timeRemaining).ToString(); // Update the text element to display the time remaining
            timeRemaining -= Time.deltaTime; // Decrease the time remaining by the time elapsed since the last frame
            if (timeRemaining <= 0) // If the time remaining has reached 0
            {
                StopTimer(); // Stop the timer
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
            }
        }
    }
}

