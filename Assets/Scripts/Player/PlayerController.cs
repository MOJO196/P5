using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
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
    
    public int currentLevel = 0;
    public float size = 10f;
    public float speed = 5f;
    public float jumpSpeed = 12f;
    public float jumpPadSpeed;
    private float movement;
    public float groundCheckRadius;
    public bool isTouchingGround;
    public bool isFacingRight = true;
    public bool ableToSkip = true;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayer;
    public LayerMask catLayer;
    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        GameStats.currentLevel = currentLevel;
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        jumpPadSpeed = jumpSpeed*1.8f;

        switch (GameStats.player)
       {
            case 1: playerAnimation.SetInteger("Player", 1);
            break;
            case 2: playerAnimation.SetInteger("Player", 2);
            break;
            case 3: playerAnimation.SetInteger("Player", 3);
            break;
            case 4: playerAnimation.SetInteger("Player", 4);
            break;
       }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(size,size);
        movement = Input.GetAxis("Horizontal");
        
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            isFacingRight = true;
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-size,size);
            isFacingRight = false;
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            isFacingRight = true;
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            FindObjectOfType<AudioManager>().Play("Jump_1");
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs (rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        if (Input.GetAxis("SkipLevel") != 0)
        {
            if (ableToSkip == true)
            {
                ableToSkip = false;
                Level_Loader.instance.LoadNextLevel();
            }
           
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            FindObjectOfType<AudioManager>().Play("CoinCollected");
            Destroy(other.gameObject);
            GameStats.score++;
        }

        if(other.gameObject.CompareTag("JumpPad"))
        {         
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPadSpeed);
            FindObjectOfType<AudioManager>().Play("JumpPad");
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, groundCheckRadius, groundLayer+catLayer);

        if (hit.collider != null)
        {
            float distace = Mathf.Abs(hit.point.y-transform.position.y);

            if (hit.transform.gameObject.layer == 9 && !isTouchingGround)
            {
                FindObjectOfType<AudioManager>().Play("Cat");
                GameStats.score+=2;
                Destroy(hit.transform.gameObject);
            }
            
            if (hit.transform.gameObject.layer == 8)
            {
                isTouchingGround = true;
            }
        }

        else
        {
            isTouchingGround = false;
        }
    }
}
