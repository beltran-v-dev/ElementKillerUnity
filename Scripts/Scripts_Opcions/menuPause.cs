using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Pauses the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);  // Display the pause menu UI
        Time.timeScale = 0f;   // Set the time scale to 0, effectively pausing the game
        gameIsPaused = true;   // Set the gameIsPaused flag to true
    }

    // Resumes the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hide the pause menu UI
        Time.timeScale = 1f;   // Reset the time scale to normal speed
        gameIsPaused = false;  // Set the gameIsPaused flag to false
    }

    // Quits the game and returns to the main menu
    public void Quit()
    {
        SceneManager.LoadScene("Menu");   // Load the "Menu" scene
    }
}
