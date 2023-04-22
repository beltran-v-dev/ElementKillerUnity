using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wall : MonoBehaviour
{
    [SerializeField(), Range(1f, 4f)]
    public float speed;

    private Rigidbody2D rb2d;

    public float visionRadius;

    public GameObject player;

    public bool movRegular;

    private Vector2 dir = new Vector2(0, -1);
    private Vector2 dirR = new Vector2(1, 0);
    private float dist = 0.3f;
    private float distR = 0.1f;
    private float distL = -0.1f;
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        movRegular = true;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y + 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y + 1), dirR * distR, Color.blue);

        //  Debug.Log(hitL_.collider);
        // Debug.Log(hitR_.collider);

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
        //float dist = Mathf.Abs(player.transform.position.x - transform.position.x);
        float dist = Vector2.Distance(player.transform.position, transform.position);
        // Debug.Log("Dist = " + dist);
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
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }

        if (movRegular == false && dist < visionRadius)
        {
            if (speed >= 1)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
                // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if (speed <= -1)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), -speed * Time.deltaTime);

                //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}