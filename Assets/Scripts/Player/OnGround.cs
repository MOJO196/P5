using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    public bool onGround;

    void Update()
    {
        if (onGround == true)
        {
            PlayerController.instance.isTouchingGround = true;
        }
        else
        {
            PlayerController.instance.isTouchingGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
}
