using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;  // Assign PauseMenu panel in Inspector
    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);  // Hide pause menu on start
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;  // Freeze game time
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;  // Resume game time
        isPaused = false;
    }

    public void QuitGame()
    {

        Time.timeScale = 1f; // Make sure game is not paused anymore
        SceneManager.LoadScene("MenuScene");
        // If building standalone:
        // Debug.Log("Quit Game");
        // Application.Quit();
    }
}
