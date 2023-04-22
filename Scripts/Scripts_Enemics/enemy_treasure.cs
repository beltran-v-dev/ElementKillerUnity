using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_treasure : MonoBehaviour
{
    GameObject player;
    private SpriteRenderer Sprite;
    private void Start()
    {
        player = GameObject.Find("Player");
        Sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 111.0 && player.transform.position.x < 114.0 && player.transform.position.y > -3.25f)
        {
            Sprite.sprite = Resources.Load<Sprite>("enemic_aigua_2");
            this.GetComponent<enemy_wall_left_2>().enabled = true;
        }


    }
}
