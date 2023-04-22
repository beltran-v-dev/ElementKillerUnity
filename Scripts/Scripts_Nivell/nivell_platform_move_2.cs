using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_platform_move_2 : MonoBehaviour
{
    public Transform from;
    public Transform to;

    public GameObject player;

    private Rigidbody2D rb2dPlayer;

    public float speed = 0.5f;

    private Vector2 posFixedStart;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private void Start()
    {
        to.parent = null;

        startPosition = from.transform.position;
        endPosition = to.transform.position;
        posFixedStart = startPosition;

        rb2dPlayer = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, to.position, speed * Time.deltaTime);

        startPosition = from.position;

        if (startPosition.x == endPosition.x)
        {
            to.position = posFixedStart;
        }
        else if (startPosition.x == to.position.x)
        {
            to.position = endPosition;

            // Debug.Log(transform.position.x);
        }

        void OnDrawGizmosSelected()
        {
            if (from != null && to != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(from.position, to.position);
                Gizmos.DrawSphere(from.position, 0.15f);
                Gizmos.DrawSphere(to.position, 0.15f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionsEntery)
    {
       // rb2dPlayer.velocity = new Vector3(0f, 0f, 0f);
        player.transform.parent = collisionsEntery.transform;
    }

    private void OnCollisionExit2D(Collision2D collisionExit)
    {
        player.transform.parent = null;
    }
}