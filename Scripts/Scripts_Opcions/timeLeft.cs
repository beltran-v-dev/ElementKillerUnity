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
        //comptador = comptador.GetComponent<TextMeshProUGUI>();
        comptador.SetText(tempsRestant + "s");
        tempsRestant = 75;
    }

    // Update is called once per frame
    void Update()
    {
        tempsRestant -= Time.deltaTime;
        TimeSpan t = TimeSpan.FromSeconds(tempsRestant);
        StringTempsRestant = string.Format("{0:D2}:{1:D2}",t.Minutes,t.Seconds);

        //comptador.SetText(String.Format("{0:0} s", tempsRestant));

        comptador.SetText(StringTempsRestant);

        if(tempsRestant <= 0)
        {
            canvasYouDied.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}