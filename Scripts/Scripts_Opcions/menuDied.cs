using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuDied : MonoBehaviour
{
    //public GameObject canvasYouDied;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("ElementKiller1.2");
        }
    }
}
