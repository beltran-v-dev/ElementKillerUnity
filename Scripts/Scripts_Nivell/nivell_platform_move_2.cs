using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_platform_move_2 : MonoBehaviour
{
    public Transform from;   // The starting point of the platform's movement
    public Transform to;     // The ending point of the platform's movement

    public GameObject player;    // Reference to the player object that interacts with the platform

    private Rigidbody2D rb2dPlayer;    // Rigidbody2D component of the player

    public float speed = 0.5f;   // The speed at which the platform moves

    private Vector2 posFixedStart;    // A fixed starting position to ensure accuracy
    private Vector2 startPosition;    // The current starting position
    private Vector2 endPosition;      // The ending position

    private void Start()
    {
        to.parent = null;   // Detach 'to' from its parent to ensure proper movement

        startPosition = from.transform.position;
        endPosition = to.transform.position;
        posFixedStart = startPosition;

        rb2dPlayer = player.GetComponent<Rigidbody2D>();   // Get the Rigidbody2D component of the player
    }



    private void FixedUpdate()
    {
        // Move the platform towards 'to' position at a constant speed
        transform.position = Vector2.MoveTowards(transform.position, to.position, speed * Time.deltaTime);

        startPosition = from.position;

        // Check if the platform has reached its destination, and reset the destination accordingly
        if (startPosition.x == endPosition.x)
        {
            to.position = posFixedStart;
        }
        else if (startPosition.x == to.position.x)
        {
            to.position = endPosition;
            // Debug.Log(transform.position.x);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the platform's movement path in the Scene view
        if (from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionsEnter)
    {
        // Set the player's parent to the platform when collision occurs (e.g., player steps onto platform)
        player.transform.parent = collisionsEnter.transform;
    }

    private void OnCollisionExit2D(Collision2D collisionExit)
    {
        // Remove the player's parent when they leave the platform
        player.transform.parent = null;
    }
}
