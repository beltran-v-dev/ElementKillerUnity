using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options_restart : MonoBehaviour
{
    GameObject player;
    public GameObject canvasYouDied, canvasYouWin;

    private void Start()
    {
        // Find the player GameObject by name
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Restart the game if "T" is pressed or if the player falls below a certain y-position
        if (Input.GetKeyDown(KeyCode.T) || player.transform.position.y < -22)
        {
            canvasYouDied.SetActive(true);
            Time.timeScale = 0f;
        }

        // Display the victory screen if the player reaches a certain position
        if (player.transform.position.x >= 149 && player.transform.position.y >= 12f)
        {
            canvasYouWin.SetActive(true);
            Time.timeScale = 0f;

            // Allow restarting the game when any key is pressed after winning
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("ElementKiller1.2");
            }
        }
    }
}
