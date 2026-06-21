using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // score = keeps track of current score
    private float score = 0f;

    // highScore = the best score ever achieved
    private float highScore = 0f;

    // isGameOver = is the game over?
    private bool isGameOver = false;

    // scoreText = the ScoreText UI element on screen
    public TextMeshProUGUI scoreText;

    // highScoreText = the HighScore UI element on screen
    public TextMeshProUGUI highScoreText;

    // finalScoreText = shows final score on Game Over screen
    public TextMeshProUGUI finalScoreText;

    // gameOverPanel = the Game Over screen panel
    public GameObject gameOverPanel;

    // Start() = runs once when game starts
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = "Best: " + (int)highScore;

        // Force play background music
        GetComponent<AudioSource>().Play();
    }

    // Update() = runs every frame
    void Update()
    {
        // Only increase score if game is not over
        if (!isGameOver)
        {
            // Increase score over time smoothly
            score += Time.deltaTime * 5f;

            // Update the score text on screen
            scoreText.text = "Score: " + (int)score;

            // Check if current score beats high score
            if (score > highScore)
            {
                // Update high score
                highScore = score;

                // Save new high score to computer
                PlayerPrefs.SetFloat("HighScore", highScore);

                // Update high score text on screen
                highScoreText.text = "Best: " + (int)highScore;
            }
        }
    }

    // GameOver() = called when player hits obstacle
    public void GameOver()
    {
        // Stop increasing score
        isGameOver = true;

        // Show final score on Game Over screen
        // (int) = convert decimal to whole number
        finalScoreText.text = "Score: " + (int)score;

        // Show the Game Over panel
        gameOverPanel.SetActive(true);

        // Stop background music
        GetComponent<AudioSource>().Stop();

        // Freeze everything in game
        Time.timeScale = 0f;
    }

    // RestartGame() = called when Restart button is clicked
    public void RestartGame()
    {
        // Restore time back to normal speed
        Time.timeScale = 1f;

        // Reload the current scene = restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}