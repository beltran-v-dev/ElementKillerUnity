using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moviment : MonoBehaviour
{
    // Movement speed of the enemy
    [SerializeField(), Range(1f, 4f)]
    public float speed;

    private Rigidbody2D rb2d;

    // Range within which the enemy detects the player
    public float visionRadius;

    // Reference to the player GameObject
    public GameObject player;

    // Flag to control regular movement behavior
    public bool movRegular;

    // Direction vectors for raycasting
    private Vector2 dir = new Vector2(0, -1);
    private Vector2 dirR = new Vector2(1, 0);

    // Distances for raycasting
    private float dist = 0.3f;
    private float distR = 2f;
    private float distL = -2f;

    // Raycast hits for movement detection
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;

    private bool control;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Find the player GameObject using tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Initialize the regular movement flag
        movRegular = true;
    }

    private void Update()
    {
        // Raycast to detect obstacles on the left side
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y - 1f), dirR * distL, Color.blue);

        // Raycast to detect obstacles on the right side
        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y - 1f), dirR * distR, Color.blue);

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

        // Check if the player is within the vision radius
        if (dist < visionRadius)
        {
            movRegular = false;
        }
        else
        {
            movRegular = true;
        }

        // Move regularly if the player is not within vision radius
        if (movRegular == true)
        {
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        // Move towards the player if the player is within vision radius
        if (movRegular == false && dist < visionRadius)
        {
            if (speed > 1)
            {
               // Debug.Log("Moving towards Right");
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), -3);
            }
            else if (speed <= -1)
            {
                //Debug.Log("Moving towards Left");
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), 3);
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
