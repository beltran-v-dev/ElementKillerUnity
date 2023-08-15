using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_final : MonoBehaviour
{
    // Speed range for the enemy's movement
    [SerializeField(), Range(1f, 4f)]
    public float speed;

    private Rigidbody2D rb2d;

    // Radius of vision for detecting the player
    public float visionRadius;

    // Reference to the player GameObject
    public GameObject player;

    // Flag to control regular movement
    public bool movRegular;

    // Direction vectors for movement checks
    private Vector2 dir = new Vector2(0, -1);
    private Vector2 dirR = new Vector2(1, 0);

    // Distances for raycasting
    private float dist = 0.3f;
    private float distR = 0.1f;
    private float distL = -0.1f;

    // Raycast hits for movement detection
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb2d = GetComponent<Rigidbody2D>();

        // Find the player GameObject with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Initialize movement flag to true
        movRegular = true;
    }

    private void FixedUpdate()
    {
        // Raycast to detect obstacles on the left side
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y - 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y - 1), dirR * distL, Color.blue);

        // Raycast to detect obstacles on the right side
        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 3f, transform.position.y - 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 3f, transform.position.y - 1), dirR * distR, Color.blue);

        // Check if there's an obstacle on the left, change direction if not
        if (hitL_.collider == null)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        // Check if there's an obstacle on the right, change direction if not
        if (hitR_.collider == null)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        // Calculate the distance between the enemy and player
        float dist = Vector2.Distance(player.transform.position, transform.position);

        // If player is within vision radius, set regular movement to false
        if (dist < visionRadius)
        {
            movRegular = false;
        }
        else
        {
            movRegular = true;
        }

        // If regular movement flag is true, move the enemy
        if (movRegular == true)
        {
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        // If regular movement flag is false and player is within vision radius
        if (movRegular == false && dist < visionRadius)
        {
            // Move towards the player based on speed
            if (speed >= 1)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
            }
            else if (speed <= -1)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), -speed * Time.deltaTime);
            }
        }
    }

    // Draw the vision radius of the enemy in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
