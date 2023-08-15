using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wall_2 : MonoBehaviour
{
    [SerializeField]
    private GameObject player; // Reference to the player GameObject.

    [SerializeField]
    private float agroRange; // Range within which the enemy detects the player.

    [SerializeField]
    private float movSpeed; // Speed at which the enemy moves.

    public float speedDetectPlayer; // Speed at which the enemy moves when detecting the player.

    public bool movRegularD; // Flag to indicate regular movement mode.

    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component of the enemy.

    public bool limit; // Flag to control movement limits.

    private Vector2 dir = new Vector2(0, -1); // Direction for raycast.
    private Vector2 dirR = new Vector2(1, 0); // Right direction for raycast.
    private float dist = 0.3f; // Raycast distance downward.
    private float distR = 0.3f; // Raycast distance right.
    private float distL = -0.3f; // Raycast distance left.
    private RaycastHit2D hit_, hitR_, hitL_; // Raycast hits for detection.

    public bool esq; // Flag indicating movement to the left.
    public bool dret; // Flag indicating movement to the right.

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D reference.

        limit = false; // Set initial movement limit to false.

        movRegularD = true; // Set initial movement mode to regular.
    }

    private void FixedUpdate()
    {
        // Perform raycasts to detect obstacles on the left and right sides.
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y + 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y + 1), dirR * distR, Color.blue);

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Detect whether the player is within the aggro range and adjust movement accordingly.
        if (distanceToPlayer < agroRange)
        {
            movToPlayer();
        }
        else
        {
            movRegular();
        }

        // Debug.Log(rb2d.velocity);
    }

    private void movRegular()
    {
        movRegularD = true; // Set the movement mode to regular.

        if (limit == false)
        {
            // Move the enemy left at regular movement speed.
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }

        if (hitL_.collider != null)
        {
            // Move the enemy right upon hitting an obstacle on the left.
            rb2d.velocity = new Vector2(+movSpeed, transform.position.y);
            limit = true;
        }

        if (hitR_.collider != null)
        {
            // Move the enemy left upon hitting an obstacle on the right.
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
            limit = true;
        }
    }

    private void movToPlayer()
    {
        movRegularD = false; // Set the movement mode to follow the player.

        if (transform.position.x <= player.transform.position.x)
        {
            // Move the enemy towards the player if the player is to the right.
            speedDetectPlayer = +movSpeed;
            rb2d.velocity = new Vector2(movSpeed, transform.position.y);
        }

        if (transform.position.x >= player.transform.position.x)
        {
            // Move the enemy towards the player if the player is to the left.
            speedDetectPlayer = -movSpeed;
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange); // Draw a visual sphere to represent the aggro range.
    }
}
