using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_tresor_vida : MonoBehaviour
{
    private SpriteRenderer Sprite;    // The SpriteRenderer component of the treasure

    private void Start()
    {
        Sprite = this.GetComponent<SpriteRenderer>();   // Get the SpriteRenderer component of the treasure
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);   // Destroy the treasure when the player touches it
        }
    }
}
