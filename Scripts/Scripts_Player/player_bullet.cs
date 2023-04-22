using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que conté cada bala al ser instanciada i fa control del mal que ha de fer segons l'enemic que toca i l'element que és l'usuari.
public class player_bullet : MonoBehaviour
{
    //Declaració de variables necessàries.
    public float speed = 1300.0f;

    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameObject explosio;
    public GameObject player;
    private int colorBlau, colorVerm, colorVerd, element;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * Time.deltaTime, 0);

        // Segons l'escala (direcció que mira) l'usuari dispararem la bala en una direcció o una altre.
        player = GameObject.Find("Player");

        if (player.transform.localScale.x == -1)
        {
            rb.velocity = -rb.velocity;
        }

        // Busquem els límits de la pantalla per la part dreta.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    private void Update()
    {
        // Del objecte Shoot, agafem l'script player_shoot per consultar el número
        // d'element que és i assignem uns valors de mal segons aquest.
        GameObject mal = GameObject.Find("Shoot");
        player_shoot tipusElement = mal.GetComponent<player_shoot>();

        if (tipusElement.element == 1)
        {
            colorVerm = 120;
            colorBlau = 40;
            colorVerd = 60;
        }

        if (tipusElement.element == 2)
        {
            colorVerm = 60;
            colorBlau = 120;
            colorVerd = 40;
        }

        if (tipusElement.element == 3)
        {
            colorVerm = 40;
            colorBlau = 60;
            colorVerd = 120;
        }

        // Si la bala surt de la pantalla es destrueix.
        //if (transform.position.x > screenBounds.x + 1)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    // Control de l'enemic que impacta la bala i cridem el mètode que té cada enemic per aplicar el mal i destrucció de la bala.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemic")
        {
            enemy_vida enemic = collision.GetComponent<enemy_vida>();
            if (enemic != null)
            {
                enemic.TakeDamage(colorVerm);
            }
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemic_2")
        {
            enemy_vida enemic = collision.GetComponent<enemy_vida>();
            if (enemic != null)
            {
                enemic.TakeDamage(colorBlau);
            }
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemic_3")
        {
            enemy_vida enemic = collision.GetComponent<enemy_vida>();
            if (enemic != null)
            {
                enemic.TakeDamage(colorVerd);
            }
            Destroy(this.gameObject);
        }

        // Si la bala toca algun objecte del nivell es destrueix.
        if (collision.tag == "Nivell")
        {
            Destroy(this.gameObject);
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}