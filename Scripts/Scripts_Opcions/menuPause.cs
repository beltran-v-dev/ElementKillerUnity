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

    public void Pause()
    {
        //iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(3, 0, 0), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine));
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}