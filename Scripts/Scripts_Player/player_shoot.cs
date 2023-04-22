using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe per disparar i canviar d'element que assigna un número a cada element segons el tipus que és l'usuari.
public class player_shoot : MonoBehaviour
{
    // Declaració de les variables necessàries.
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabLeft;
    private SpriteRenderer m_SpriteRenderer;
    public float element;
    private bool esPotDisparar;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private Animator animacio;

    private void Start()
    {

        // Obtenim el Renderitzador de Sprites del objecte Player.
        player = GameObject.Find("Player");
        //m_SpriteRenderer = player.GetComponent<SpriteRenderer>();
        animacio = player.GetComponent<Animator>();
        element = 0;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        player_moviment speed = player.GetComponent<player_moviment>();

        if (element == 0)
        {
            esPotDisparar = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animacio.SetInteger("idle", 1);
        }

        else
        {
            animacio.SetInteger("idle", 0);
        }

        // Segons la tecla que es pressioni es canviarà d'element al jugador i s'assignarà a la variable element.
        if (Input.GetKey("1"))
        {
            //m_SpriteRenderer.sprite = Resources.Load<Sprite>("player_foc");
            animacio.SetInteger("color", 1);
            element = 1;
            esPotDisparar = true;
        }

        if (Input.GetKey("2"))
        {
            animacio.SetInteger("color", 2);
            //m_SpriteRenderer.sprite = Resources.Load<Sprite>("player_planta");
            element = 2;
            esPotDisparar = true;
        }

        if (Input.GetKey("3"))
        {
            //m_SpriteRenderer.sprite = Resources.Load<Sprite>("player_aigua");
            animacio.SetInteger("color", 3);
            element = 3;
            esPotDisparar = true;
        }

        // Control de la direcció del dispar segons la direcció que està mirant l'usuari.
        if (Input.GetMouseButtonDown(0) && player.transform.localScale.x == 1 && esPotDisparar == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            disparar();
        }

        if (Input.GetMouseButtonDown(0) && player.transform.localScale.x == -1 && esPotDisparar == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            disparar2();
        }
    }

    // Instanciem el prefab de bala corresponent a cada cas.
    public void disparar()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = this.transform.position;
    }

    public void disparar2()
    {
        GameObject b = Instantiate(bulletPrefabLeft) as GameObject;
        b.transform.position = this.transform.position;
    }

}
