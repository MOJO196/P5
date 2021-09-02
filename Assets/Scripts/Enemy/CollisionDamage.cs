using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{

    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Player"))
            other.SendMessage("ApplyDamage",damage);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag ("Player"))
            other.SendMessage("ApplyDamage",damage);
    }
}
