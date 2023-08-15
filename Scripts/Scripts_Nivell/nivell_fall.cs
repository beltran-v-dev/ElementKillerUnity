using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_fall : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Collider2D collider;
    private Vector2 position;

    public float fallDelay = 0.1f;
    public float resDelay = 1f;

    private void Start()
    {
        // Get the Rigidbody2D component attached to this object
        rb2d = GetComponent<Rigidbody2D>();

        // Get the Collider2D component attached to this object
        collider = GetComponent<Collider2D>();

        // Store the initial position of the object
        position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Invoke the "Fall" method after the specified fallDelay time
            Invoke("Fall", fallDelay);
;
        }
    }

    private void Fall()
    {
        // Allow physics to affect the object
        rb2d.isKinematic = false;

        // Disable the collider to prevent further interactions
        collider.enabled = false;
    }

    private void Respawn()
    {
        // Reset the object's position to its initial position
        transform.position = position;

        // Restore kinematic state and reset velocity
        rb2d.isKinematic = true;
        rb2d.velocity = Vector2.zero;
    }
}
