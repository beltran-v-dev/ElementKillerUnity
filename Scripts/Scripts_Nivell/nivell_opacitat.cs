using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivell_opacitat : MonoBehaviour
{
    Color tmp, tmp2;
    private void Start()
    {
        tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;

        tmp2.r = 255f;
        tmp2.g = 255f;
        tmp2.b = 255f;
        tmp2.a = 255f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().color = tmp;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().color = tmp2;
        }

    }
}

