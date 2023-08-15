using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moviment_2 : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Range within which the enemy detects the player
    [SerializeField]
    private float agroRange;

    // Movement speed of the enemy
    [SerializeField]
    private float movSpeed;

    public float speedDetectPlayer;

    // Flag to control movement behavior
    public bool movRegularD;

    private Rigidbody2D rb2d;

    // Flag to control if movement is limited
    public bool limit;

    // Direction vectors for raycasting
    private Vector2 dir = new Vector2(0, -1);
    private Vector2 dirR = new Vector2(1, 0);

    // Distances for raycasting
    private float dist = 0.3f;
    private float distR = 2f;
    private float distL = -2f;

    // Raycast hits for movement detection
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;

    // Flags for movement direction
    public bool esq;
    public bool dret;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Initialize movement limit flag
        limit = false;

        // Initialize regular movement flag
        movRegularD = true;
    }

    private void FixedUpdate()
    {
        // Raycast to detect obstacles on the left side
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y - 1f), dirR * distL, Color.blue);

        // Raycast to detect obstacles on the right side
        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y - 1f), dirR * distR, Color.blue);

        // Calculate the distance between the enemy and player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // If the player is within agro range, move towards the player
        if (distanceToPlayer < agroRange)
        {
            movToPlayer();
        }

        // If the player is outside agro range, move regularly
        if (distanceToPlayer > agroRange)
        {
            movRegular();
        }

        // Debug.Log(rb2d.velocity);
    }

    private void movRegular()
    {
        // Set the regular movement flag
        movRegularD = true;

        // If movement is not limited
        if (limit == false)
        {
            // Move left
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }
        else if (hitR_.collider == null)
        {
            // Move left if right side is clear
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
            limit = true;
        }

        // If left side is clear, move right
        if (hitL_.collider == null)
        {
            rb2d.velocity = new Vector2(+movSpeed, transform.position.y);
            limit = true;
        }

        // If right side is clear, move left
        if (hitR_.collider == null)
        {
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
            limit = true;
        }
    }

    private void movToPlayer()
    {
        // Set the regular movement flag to false
        movRegularD = false;

        // Move towards the player based on player's position
        if (transform.position.x <= player.transform.position.x)
        {
            speedDetectPlayer = +movSpeed;
            rb2d.velocity = new Vector2(movSpeed, transform.position.y);
        }

        if (transform.position.x >= player.transform.position.x)
        {
            speedDetectPlayer = -movSpeed;
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }
    }

    // Draw the agro range of the enemy in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }
}
