using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that manages the life control of each enemy object.
public class enemy_vida : MonoBehaviour
{
   // Initial health and death animation.
    public int health = 120;
    public GameObject explosio;

// Method called from player_bullet to gradually decrease the enemy's health based on the element.
public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage);

        if (health <= 0)
        {
            Die();
        }
    }

// Death animation and destruction of the enemy along with the death animation.
    private void Die()
    {
        GameObject e = Instantiate(explosio) as GameObject;
        e.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y + 0.6f);
        Destroy(gameObject);
    }
}
