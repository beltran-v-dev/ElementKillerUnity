using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moviment : MonoBehaviour
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
    private float distR = 2f;
    private float distL = -2f;
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;
    private bool control;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        movRegular = true;
    }

    private void Update()

    {
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y - 1f), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y - 1f), dirR * distR, Color.blue);

        if (hitL_.collider == null)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (hitR_.collider == null)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(+speed, rb2d.velocity.y);
        }
        //float dist = Mathf.Abs(player.transform.position.x - transform.position.x);
        
        float dist = Vector2.Distance(player.transform.position, transform.position);
        //Debug.Log("Dist = " + dist);
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
            if (speed > 1)
            {
                Debug.Log("Moviment cap a Dreta");
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), -3);
                //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0), speed * Time.deltaTime);


            }
            else if (speed <= -1)
            {
                Debug.Log("Moviment cap a Esquerra");
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, transform.position.y), 3);
                //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0), -speed * Time.deltaTime);

            }
        }
    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}