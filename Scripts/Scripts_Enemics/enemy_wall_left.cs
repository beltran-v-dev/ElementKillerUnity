using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wall_left : MonoBehaviour
{
    [SerializeField(), Range(1f, 4f)]
    public float speed; // Movement speed of the enemy.

    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component.

    public float visionRadius; // Radius within which the enemy detects the player.

    public GameObject player; // Reference to the player GameObject.

    public bool movRegular; // Flag indicating regular movement mode.

    private Vector2 dir = new Vector2(0, -1); // Direction for raycast.
    private Vector2 dirR = new Vector2(1, 0); // Right direction for raycast.
    private float dist = 0.3f; // Raycast distance downward.
    private float distR = 0.1f; // Raycast distance right.
    private float distL = -0.1f; // Raycast distance left.
    private RaycastHit2D hit_, hitR_, hitL_; // Raycast hits for detection.

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D reference.

        player = GameObject.FindGameObjectWithTag("Player"); // Find and assign the player GameObject.

        movRegular = true; // Set initial movement mode to regular.
    }

    private void Update()
    {
        // Empty Update method.
    }

    private void FixedUpdate()
    {
        // Perform raycasts to detect obstacles on the left and right sides.
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y - 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y - 1), dirR * distR, Color.blue);

        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (hitL_.collider != null)
        {
            // Reverse movement direction upon hitting an obstacle on the left.
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (hitR_.collider == null)
        {
            // Reverse movement direction upon no obstacle detected on the right.
            speed = -speed;
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        // Detect whether the player is within the aggro range and adjust movement accordingly.
        if (dist < visionRadius)
        {
            movRegular = false;
        }
        else
        {
            movRegular = true;
        }

        if (movRegular == true)
        {
            // Move the enemy at regular speed.
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        if (movRegular == false && dist < visionRadius)
        {
            // Move the enemy towards the player based on speed.
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius); // Draw a visual sphere to represent the aggro range.
    }
}
