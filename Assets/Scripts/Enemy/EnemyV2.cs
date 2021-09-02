using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    bool facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other != null && !other.collider.CompareTag("Player") && other.collider.CompareTag("Ground"))
        {
            facingLeft = !facingLeft;
        }

        if(facingLeft)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
