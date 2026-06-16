using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    // pausePanel = the Pause screen panel
    public GameObject pausePanel;

    // pauseButton = the pause button on screen
    public GameObject pauseButton;

    // isPaused = is the game currently paused?
    private bool isPaused = false;

    // TogglePause() = called when Pause button is clicked
    // Toggle = switch between paused and unpaused
    public void TogglePause()
    {
        if (isPaused)
        {
            // Game is paused → Resume it!
            ResumeGame();
        }
        else
        {
            // Game is running → Pause it!
            PauseGame();
        }
    }

    // PauseGame() = pauses the game
    void PauseGame()
    {
        // Set isPaused to true
        isPaused = true;

        // Show pause panel
        pausePanel.SetActive(true);

        // Hide pause button while paused
        pauseButton.SetActive(false);

        // Time.timeScale = 0f = freeze everything in game
        Time.timeScale = 0f;
    }

    // ResumeGame() = resumes the game
    public void ResumeGame()
    {
        // Set isPaused to false
        isPaused = false;

        // Hide pause panel
        pausePanel.SetActive(false);

        // Show pause button again
        pauseButton.SetActive(true);

        // Time.timeScale = 1f = restore normal speed
        Time.timeScale = 1f;
    }
}