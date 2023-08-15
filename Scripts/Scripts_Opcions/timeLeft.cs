using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timeLeft : MonoBehaviour
{
    public float tempsRestant; //= 65;
    public string StringTempsRestant;
    public GameObject canvasYouDied;
    public TextMeshProUGUI comptador;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the countdown timer
        comptador.SetText(tempsRestant + "s");
        tempsRestant = 75;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the remaining time and display it
        tempsRestant -= Time.deltaTime;
        TimeSpan t = TimeSpan.FromSeconds(tempsRestant);
        StringTempsRestant = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        comptador.SetText(StringTempsRestant);

        // Check if time has run out and display the "You Died" canvas
        if (tempsRestant <= 0)
        {
            canvasYouDied.SetActive(true);
            Time.timeScale = 0f; // Freeze the game
        }
    }
}
