using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 1f;
    Rigidbody2D rigidBody;
    Transform target;
    [HideInInspector]

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime)*new Vector2 (1,0)+new Vector2(0,transform.position.y);

        if(target.position.x - transform.position.x >= 0)
        {
            transform.localScale = new Vector2 (-10, 10);
        }
        else
        {
            transform.localScale = new Vector2 (10, 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Player"))
        {
            //FindObjectOfType<AudioManager>().Play("Robot");
            other.SendMessage("ApplyDamage",damage);
        }
        else if (other.CompareTag ("Enemy"))
        {
            Debug.Log("Enemy");
            //FindObjectOfType<AudioManager>().Play("Robot");
            Destroy(gameObject);
            //Maarten fragen 
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag ("Player"))
        {
            other.SendMessage("ApplyDamage",damage);
        }
    }
}
