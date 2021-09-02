using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : MonoBehaviour
{
    public static Boss_2 instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

	public int damageTime = 5;
	public bool dead = false;
	public int health = 20;
    public int maxHealth = 20;
    public float size = 10f;
    public float speed = 20f;
    public float jumpSpeed = 10f;
    private float movement = 0f;
    public float groundCheckRadius;
    private bool isTouchingGround;
	private bool isDamageable = true;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    private Animator playerAnimation;

	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        //FindObjectOfType<AudioManager>().Play("Boss_2");
    }

	void Update()
    {
        if(!dead)
        {
            transform.localScale = new Vector2(-size,size);
            isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
            movement = Input.GetAxis("Horizontal");
            
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
	}

    public void TakeDamage (int damage)
    {
		if(isDamageable)
		{
			isDamageable = false;
			health -= damage;
			Invoke("Attack", 0);
			Invoke("ResetIsDamageable", damageTime);

			if (health == 10)
			{
				Boss_2_Attack.instance.delayTime = 2.5f;
			}

			if (health <= 0)
			{
				Die();
				StartCoroutine(Teleport());
			}
		}
    }

	void ResetIsDamageable()
    {
        isDamageable = true;
    }

	void Attack ()
	{
		Boss_2_Attack.instance.Attack();
	}

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Level_Loader.instance.LoadNextLevel();
    }

	public void Die ()
    {
        dead = true;
        Debug.Log ("Boss_2 wurde besiegt");
    }
}