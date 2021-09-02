using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{    
    public int health = 20;
    public GameObject deathEffekt;
    
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die ()
    {
        //Instantiate(deathEffekt, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}