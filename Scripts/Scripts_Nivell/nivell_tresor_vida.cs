using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_tresor_vida : MonoBehaviour
{
    private SpriteRenderer Sprite;

    private void Start()
    {
        Sprite = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

        }

    }
}
