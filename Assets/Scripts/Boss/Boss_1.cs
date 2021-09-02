using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_1 : MonoBehaviour
{
    private const int X = 0;
    public int health = 20;
    public int maxHealth = 20;
    public float size = 10f;
    public float speed = 20f;
    public float jumpSpeed = 5f;
    public float damage = 1f;
    private float movement = 0f;
    public float groundCheckRadius;
    private bool isTouchingGround;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    private Animator playerAnimation;
    public GameObject tp, player;
    private Transform target;
    public bool v2 = false;
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
        if(!dead)
        {
            if(!v2)
            {
                transform.localScale = new Vector2(-size,size);
                isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
                movement = Input.GetAxis("Horizontal");
                //Debug.Log(movement);
                if (movement > 0f)
                {
                    rigidBody.velocity = new Vector2(-movement * speed, rigidBody.velocity.y);
                    //transform.localScale = new Vector2(-size,size);

                }
                else if (movement < 0f)
                {
                    rigidBody.velocity = new Vector2 (-movement * speed, rigidBody.velocity.y);
                    transform.localScale = new Vector2(size,size);
                }
                else
                {
                    rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                }

                if (Input.GetButtonDown("Jump") && isTouchingGround)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                }

                playerAnimation.SetFloat("Speed", Mathf.Abs (rigidBody.velocity.x));
                playerAnimation.SetBool("OnGround", isTouchingGround);
            }
            else
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

                playerAnimation.SetBool("OnGround", true);
            }
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 10)
        {
            size += 2;
            transform.localScale = new Vector2(size,size);
        }

        if (health <= 0)
        {
            Die();
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Level_Loader.instance.LoadNextLevel();
        //player.transform.position = new Vector2(tp.transform.position.x, tp.transform.position.y);
    }

    public void Die ()
    {
        dead = true;
        size = 10;
        transform.localScale = new Vector2(size,size);
        Debug.Log ("Boss_1 wurde besiegt");
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