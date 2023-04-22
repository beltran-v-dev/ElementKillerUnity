using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_fall : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float fallDelay = 0.1f;
    public float resDealy = 1f;
    private Collider2D collider;
    private Vector2 position;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = this.GetComponent<Collider2D>();
        position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            //Invoke("Respawn", fallDelay + resDealy);
        }
    }

    private void Fall()
    {
        rb2d.isKinematic = false;
        collider.enabled = false;
    }

    private void Respawn()
    {
        transform.position = position;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
    }
}
