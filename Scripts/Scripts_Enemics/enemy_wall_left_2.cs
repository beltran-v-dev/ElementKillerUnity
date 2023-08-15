using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wall_left_2 : MonoBehaviour
{
    [SerializeField]
    private GameObject player; // Reference to the player GameObject.

    [SerializeField]
    private float agroRange; // Range within which the enemy detects the player.

    [SerializeField]
    private float movSpeed; // Movement speed of the enemy.

    public float speedDetectPlayer; // Speed at which the enemy detects the player.

    public bool movRegularD; // Flag for regular movement mode.

    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component.

    public bool limit; // Flag to control movement limit.

    private Vector2 dir = new Vector2(0, -1); // Direction for raycast.
    private Vector2 dirR = new Vector2(1, 0); // Right direction for raycast.
    private float dist = 0.3f; // Raycast distance downward.
    private float distR = 0.1f; // Raycast distance right.
    private float distL = -0.1f; // Raycast distance left.
    private RaycastHit2D hit_, hitR_, hitL_; // Raycast hits for detection.

    public bool esq; // Flag for left movement.
    public bool dret; // Flag for right movement.

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D reference.

        limit = false; // Set initial limit flag.

        movRegularD = true; // Set initial movement mode to regular.
    }

    private void FixedUpdate()
    {
        // Perform raycasts to detect obstacles on the left and right sides.
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y - 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y - 1), dirR * distR, Color.blue);

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < agroRange)
        {
            movToPlayer(); // Move towards the player if within aggro range.
        }

        if (distanceToPlayer > agroRange)
        {
            movRegular(); // Move regularly if outside aggro range.
        }
    }

    private void movRegular()
    {
        movRegularD = true; // Set regular movement mode.

        if (limit == false)
        {
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y); // Move left if no limit.
        }

        if (hitL_.collider != null)
        {
            rb2d.velocity = new Vector2(+movSpeed, transform.position.y); // Move right if obstacle on left.
            limit = true;
        }

        if (hitR_.collider == null)
        {
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y); // Move left if no obstacle on right.
            limit = true;
        }
    }

    private void movToPlayer()
    {
        movRegularD = false; // Set player detection movement mode.

        if (transform.position.x <= player.transform.position.x)
        {
            speedDetectPlayer = +movSpeed;
            rb2d.velocity = new Vector2(movSpeed, transform.position.y); // Move right towards player.
        }

        if (transform.position.x >= player.transform.position.x)
        {
            speedDetectPlayer = -movSpeed;
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y); // Move left towards player.
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange); // Draw aggro range.
    }
}
