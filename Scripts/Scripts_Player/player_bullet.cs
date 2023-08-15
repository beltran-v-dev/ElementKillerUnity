using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that contains each bullet when instantiated and controls the damage it should deal based on the enemy it hits and the player element
public class player_bullet : MonoBehaviour
{
    //Variables declaration
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

        // According to the scale (direction the user is facing), we will shoot the bullet in one direction or another.
        player = GameObject.Find("Player");

        if (player.transform.localScale.x == -1)
        {
            rb.velocity = -rb.velocity;
        }

        //We search for the screen boundaries on the right side.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    private void Update()
    {
     // From the Shoot object, we retrieve the player_shoot script to check the element number
    // and assign damage values accordingly.
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

    
    }

   // Handling of the enemy hit by the bullet and calling the method unique to each enemy to apply damage and destroy the bullet.
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

      // If the bullet hits any object in the level, it is destroyed.

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
