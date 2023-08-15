using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_final_2 : MonoBehaviour
{
    // Reference to the player GameObject
    [SerializeField]
    private GameObject player;

    // Range within which the enemy detects the player
    [SerializeField]
    private float agroRange;

    // Movement speed of the enemy
    [SerializeField]
    private float movSpeed;

    // Speed to detect and move towards the player
    public float speedDetectPlayer;

    // Flag to control regular movement behavior
    public bool movRegularD;

    private Rigidbody2D rb2d;

    // Flag to limit movement direction changes
    public bool limit;

    // Direction vectors for raycasting
    private Vector2 dir = new Vector2(0, -1);
    private Vector2 dirR = new Vector2(1, 0);

    // Distances for raycasting
    private float dist = 0.3f;
    private float distR = 0.1f;
    private float distL = -0.1f;

    // Raycast hits for movement detection
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;

    // Flags for movement direction
    public bool esq;
    public bool dret;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Initialize limit and regular movement flags
        limit = false;
        movRegularD = true;
    }

    private void FixedUpdate()
    {
        // Raycast to detect obstacles on the left side
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y - 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y - 1), dirR * distL, Color.blue);

        // Raycast to detect obstacles on the right side
        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 3.2f, transform.position.y - 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 3.2f, transform.position.y - 1), dirR * distR, Color.blue);

        // Calculate the distance between the enemy and player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Check if the player is within the aggro range
        if (distanceToPlayer < agroRange)
        {
            movToPlayer();
        }

        // Check if the player is outside the aggro range
        if (distanceToPlayer > agroRange)
        {
            movRegular();
        }
    }

    private void movRegular()
    {
        movRegularD = true;

        if (limit == false)
        {
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }

        // Check if there's an obstacle on the left, change direction if not
        if (hitL_.collider == null)
        {
            rb2d.velocity = new Vector2(+movSpeed, transform.position.y);
            limit = true;
        }

        // Check if there's an obstacle on the right, change direction if not
        if (hitR_.collider == null)
        {
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
            limit = true;
        }
    }

    private void movToPlayer()
    {
        movRegularD = false;

        // Move towards the player based on their position
        if (transform.position.x <= player.transform.position.x)
        {
            speedDetectPlayer = +movSpeed;
            rb2d.velocity = new Vector2(movSpeed, transform.position.y);
        }
        else if (transform.position.x >= player.transform.position.x)
        {
            speedDetectPlayer = -movSpeed;
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }
    }

    // Draw the aggro range of the enemy in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }
}
