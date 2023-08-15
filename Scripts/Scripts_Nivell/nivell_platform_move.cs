using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_platform_move : MonoBehaviour
{
    public Transform From;   // The starting point of the platform's movement
    public Transform to;     // The ending point of the platform's movement

    public float speed = 0.5f;   // The speed at which the platform moves

    private Vector2 posFixedStart;    // A fixed starting position to ensure accuracy
    private Vector2 startPosition;    // The current starting position
    private Vector2 endPosition;      // The ending position

    private void Start()
    {
        to.parent = null;   // Detach 'to' from its parent to ensure proper movement

        startPosition = From.transform.position;
        endPosition = to.transform.position;
        posFixedStart = startPosition;
    }



    private void FixedUpdate()
    {
        // Move the platform towards 'to' position at a constant speed
        transform.position = Vector2.MoveTowards(transform.position, to.position, speed * Time.deltaTime);

        startPosition = From.position;

        // Check if the platform has reached its destination, and reset the destination accordingly
        if (startPosition.x == endPosition.x)
        {
            to.position = posFixedStart;
        }
        else if (startPosition.x == to.position.x)
        {
            to.position = endPosition;
        }

        // Debug.Log(transform.position.x);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the platform's movement path in the Scene view
        if (From != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(From.position, to.position);
            Gizmos.DrawSphere(From.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }
}
