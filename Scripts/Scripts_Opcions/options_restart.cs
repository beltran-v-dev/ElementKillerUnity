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
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) || player.transform.position.y < -22)
        {
            //SceneManager.LoadScene("ElementKiller1.2");
            canvasYouDied.SetActive(true);
            Time.timeScale = 0f;
        }

        if (player.transform.position.x >= 149 && player.transform.position.y >= 12f)
        {
            canvasYouWin.SetActive(true);
            Time.timeScale = 0f;

            if (Input.anyKeyDown)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("ElementKiller1.2");
            }
        }

      
    }
}
