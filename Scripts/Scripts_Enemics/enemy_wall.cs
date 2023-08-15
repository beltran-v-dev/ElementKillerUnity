using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wall : MonoBehaviour
{
    [SerializeField(), Range(1f, 4f)]
    public float speed; // Movement speed of the enemy.

    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component of the enemy.

    public float visionRadius; // The radius within which the enemy detects the player.

    public GameObject player; // Reference to the player GameObject.

    public bool movRegular; // Bool to control regular movement.

    private Vector2 dir = new Vector2(0, -1); // Direction for raycast.
    private Vector2 dirR = new Vector2(1, 0); // Right direction for raycast.
    private float dist = 0.3f; // Raycast distance downward.
    private float distR = 0.1f; // Raycast distance right.
    private float distL = -0.1f; // Raycast distance left.
    private RaycastHit2D hit_, hitR_, hitL_; // Raycast hits for detection.

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D reference.

        player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject.

        movRegular = true; // Set initial movement mode to regular.
    }

    private void FixedUpdate()
    {
        // Perform raycasts to detect obstacles on the left and right sides.
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y + 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y + 1), dirR * distR, Color.blue);

        // Check if obstacles are detected on the left or right sides and reverse speed accordingly.
        if (hitL_.collider != null)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (hitR_.collider != null)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        // Calculate the distance between the enemy and the player.
        float dist = Vector2.Distance(player.transform.position, transform.position);

        // Determine whether the player is within the vision radius of the enemy.
        if (dist < visionRadius)
        {
            movRegular = false;
        }
        else
        {
            movRegular = true;
        }

        // Apply movement based on the current mode (regular or toward player).
        if (movRegular == true)
        {
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        if (movRegular == false && dist < visionRadius)
        {
            if (speed >= 1)
            {
                // Move the enemy towards the player at a certain speed.
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
            }
            else if (speed <= -1)
            {
                // Move the enemy away from the player at a certain speed.
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), -speed * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius); // Draw a visual sphere to represent the vision radius.
    }
}
