using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4_Junior : MonoBehaviour
{
    public int health = 20;
    public int maxHealth = 20;
    public float size = 10f;
    public float speed = 50f;
    public float damage = 1f;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayer;
    private Animator playerAnimation;
    private Transform target;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        FindObjectOfType<AudioManager>().Play("Boss_1");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime)*new Vector2 (1,0)+new Vector2(0,transform.position.y);

            if(target.position.x - transform.position.x >= 0)
            {
                transform.localScale = new Vector2 (-size, size);
            }
            else
            {
                transform.localScale = new Vector2 (size, size);
            }
        }
    }

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
        dead = true;
        Boss_4.instance.junior = false;
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        speed = 5;
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
