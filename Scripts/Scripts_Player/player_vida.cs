using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_vida : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private GameObject player;
    public GameObject canvasYouDied;
    private Animator animacio;

    public TextMeshProUGUI vidaText;

    public int vida = 5;

    public Material material;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the SpriteRenderer component of the player object
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animacio = GetComponent<Animator>();

        // Set the initial material color to black
        material.SetColor("_ToColor", Color.black);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Find the Shoot object and get its player_shoot component
        GameObject element = GameObject.Find("Shoot");
        player_shoot tipusElement = element.GetComponent<player_shoot>();

        if (collision.gameObject.tag == "Enemic" || collision.gameObject.tag == "Enemic_2" || collision.gameObject.tag == "Enemic_3")
        {
            // Change the player's sprite color and reset the element type
            animacio.SetInteger("color", 0);
            tipusElement.element = 0;

            // Destroy the enemy that collided with the player
            Destroy(collision.gameObject);

            // Decrease player's life and update the life text
            vida--;
            vidaText.SetText("" + vida);

            // Change the screen color to black
            material.SetColor("_ToColor", Color.black);

            // If player's life is zero, show "You Died!" message and pause the game
            if (vida == 0)
            {
                Debug.Log("You died!");
                canvasYouDied.SetActive(true);
                Time.timeScale = 0f; // Pause the game
            }
        }

        // If the player collides with a "Nivell" object, make it a child of that object
        if (collision.gameObject.tag == "Nivell")
        {
            transform.parent = collision.transform;
        }

        // If the player collides with a "cor" object, increase their life
        if (collision.gameObject.tag == "cor")
        {
            vida = vida + 1;
            vidaText.SetText("" + vida);
            Debug.Log(vida);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        // Change the screen color based on the pressed keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            material.SetColor("_ToColor", Color.red);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            material.SetColor("_ToColor", Color.green);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            material.SetColor("_ToColor", Color.blue);
        }
    }
}
