using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 60f;         // Total time for the level
    public TMP_Text timerText;            // UI Text to display the timer
    public bool isGameOver = false;       // Flag to check if the game is over
    private bool levelCompleted = false;  // Flag to check if level is completed

    void Update()
    {
        if (!isGameOver && !levelCompleted)
        {
            levelTime -= Time.deltaTime;  // Decrease the timer over time
            levelTime = Mathf.Max(levelTime, 0); // Ensure levelTime doesn't go below 0

            // Update the UI Text
            int minutes = Mathf.FloorToInt(levelTime / 60);
            int seconds = Mathf.FloorToInt(levelTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Check if the timer hits zero
            if (levelTime <= 0)
            {
                isGameOver = true; // End the game if timer runs out
                timerText.gameObject.SetActive(false); // Hide the timer UI
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameOver) // Only allow level completion if the game is not over
        {
            levelCompleted = true;
            Debug.Log("Level Completed!");

            // Load the next level scene (update this with the actual next level scene name)
            SceneManager.LoadScene("NextLevelScene");
        }
    }
}
