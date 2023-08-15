using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_treasure : MonoBehaviour
{
    GameObject player;
    private SpriteRenderer Sprite;

    private void Start()
    {
        // Find the player GameObject by name
        player = GameObject.Find("Player");

        // Get the SpriteRenderer component of the GameObject
        Sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player's position is within a specific range
        if (player.transform.position.x > 111.0 && player.transform.position.x < 114.0 && player.transform.position.y > -3.25f)
        {
            // Change the sprite of the enemy when the player is in the specified range
            Sprite.sprite = Resources.Load<Sprite>("enemic_aigua_2");

            // Enable the enemy_wall_left_2 script attached to this GameObject
            this.GetComponent<enemy_wall_left_2>().enabled = true;
        }
    }
}
