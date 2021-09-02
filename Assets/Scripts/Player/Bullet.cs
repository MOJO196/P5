using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destory());

        if (PlayerController.instance.isFacingRight == true)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -transform.right * speed;
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        //Debug.Log (hitInfo.name);
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            if(hitInfo.gameObject.CompareTag("Coins"))
            {
                Destroy(hitInfo.gameObject);
                GameStats.score++;
            }

            /*
            if(hitInfo.gameObject.CompareTag("Operator"))
            {
                operator.TakeDamage(damage);
                GameStats.score+=2;
            }
            */

            Enemy enemy = hitInfo.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            Boss_1 boss_1 = hitInfo.GetComponent<Boss_1>();

            if (boss_1 != null)
            {
                boss_1.TakeDamage(damage);
            }

            Boss_2 boss_2 = hitInfo.GetComponent<Boss_2>();

            if (boss_2 != null)
            {
                boss_2.TakeDamage(damage);
            }

            Boss_4_Junior boss_4_Junior = hitInfo.GetComponent<Boss_4_Junior>();

            if (boss_4_Junior != null)
            {
                boss_4_Junior.TakeDamage(damage);
            }

            Boss_5 boss_5 = hitInfo.GetComponent<Boss_5>();

            if (boss_5 != null)
            {
                boss_5.TakeDamage(damage);
            }       
        }

        Destroy(gameObject);
        StartCoroutine(Effect());
    }

    IEnumerator Effect()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);
        Destroy(impactEffect);
    }

    IEnumerator Destory ()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
