using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe enemic que fa el control de la vida de cada objecte enemic.
public class enemy_vida : MonoBehaviour
{
    //Vida inicial i animació de mort.
    public int health = 120;
    public GameObject explosio;

    // Mètode que és cridat des de player_bullet per anar restant la vida segons l'element.
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    // Animació de mort i destrucció de l'enemic i de l'animació de mort.
    private void Die()
    {
        GameObject e = Instantiate(explosio) as GameObject;
        e.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y + 0.6f);
        Destroy(gameObject);
    }
}
