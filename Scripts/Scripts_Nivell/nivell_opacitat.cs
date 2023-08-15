using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_opacitat : MonoBehaviour
{
    Color tmp, tmp2;

    private void Start()
    {
        // Store the initial color of the SpriteRenderer component
        tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;

        // Define a color that will fully restore the opacity (alpha) of the SpriteRenderer
        tmp2 = new Color(1f, 1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Set the SpriteRenderer's color to the semi-transparent color when the player enters the trigger
            this.GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Restore the SpriteRenderer's color to full opacity when the player exits the trigger
            this.GetComponent<SpriteRenderer>().color = tmp2;
        }
    }
}
