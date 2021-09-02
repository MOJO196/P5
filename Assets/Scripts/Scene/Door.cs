using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Level_Loader.instance.LoadNextLevel();
            FindObjectOfType<AudioManager>().Play("Door");
        }
    }
}
