using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_5 : MonoBehaviour
{
    private const int X = 0;
    public int health = 20;
    public float speed = 20f;
    public float jumpSpeed = 5f;
    public float damage = 1f;
    public float size = 15f;
    private Rigidbody2D rigidBody;
    private Animator playerAnimation;
    private Transform target;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        //FindObjectOfType<AudioManager>().Play("Boss_1");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime)*new Vector2 (1,0)+new Vector2(0,transform.position.y);

        if(target.position.x - transform.position.x >= 0)
        {
            transform.localScale = new Vector2 (size, size);
        }
        else
        {
            transform.localScale = new Vector2 (-size, size);
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 10)
        {
            Boss_5_Attack.instance.v2 = true;
        }

        if (health <= 5)
        {
            Boss_5_Attack.instance.delayTime/=2;
        }

        if (health <= 0)
        {
            Teleport();
            Die();
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
    }

    public void Die ()
    {
        Destroy(gameObject);
        Level_Loader.instance.LoadNextLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!dead)
        {
            if(other.CompareTag ("Player"))
            {
                other.SendMessage("ApplyDamage",damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!dead)
        {
            if(other.CompareTag ("Player"))
            {
                other.SendMessage("ApplyDamage",damage);
            }
        }
    }
}
