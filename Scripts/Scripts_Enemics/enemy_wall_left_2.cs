using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wall_left_2 : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float agroRange;

    [SerializeField]
    private float movSpeed;

    public float speedDetectPlayer;

    public bool movRegularD;

    private Rigidbody2D rb2d;

    public bool limit;

    private Vector2 dir = new Vector2(0, -1);
    private Vector2 dirR = new Vector2(1, 0);
    private float dist = 0.3f;
    private float distR = 0.1f;
    private float distL = -0.1f;
    private RaycastHit2D hit_, hitR_, hitL_, hitEnemyRight_, hitEnemyLeft_;

    public bool esq;
    public bool dret;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        limit = false;

        movRegularD = true;
    }

    private void FixedUpdate()
    {
        hitL_ = Physics2D.Raycast(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR, distL);
        Debug.DrawRay(new Vector2(transform.position.x - 0.7f, transform.position.y + 1), dirR * distL, Color.blue);

        hitR_ = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y - 1), dirR, distR);
        Debug.DrawRay(new Vector2(transform.position.x + 0.7f, transform.position.y - 1), dirR * distR, Color.blue);

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Debug.Log(distanceToPlayer);

        if (distanceToPlayer < agroRange)
        {
            movToPlayer();
        }

        if (distanceToPlayer > agroRange)
        {
            movRegular();
        }

        // Debug.Log(rb2d.velocity);
    }

    private void movRegular()
    {
        movRegularD = true;

        // Debug.Log(speedDetectPlayer);

        //rb2d.velocity = Vector2.zero;
        if (limit == false)
        {
            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
        }

        if (hitL_.collider != null)
        {
            // Debug.Log("estas apunt de surtit");

            rb2d.velocity = new Vector2(+movSpeed, transform.position.y);
            limit = true;
        }

        if (hitR_.collider == null)
        {
            // Debug.Log("estas apunt de surtit");

            rb2d.velocity = new Vector2(-movSpeed, transform.position.y);
            limit = true;
        }
    }

    private void movToPlayer()
    {
        movRegularD = false;

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }
}