using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int delTime = 5;

    void Start()
    {
        StartCoroutine(Delete(delTime));
        FindObjectOfType<AudioManager>().Play("Asteroid");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
           HealthController.instance.ApplyDamage(1);
       }
    }

    IEnumerator Delete (int delTime)
    {
        yield return new WaitForSeconds(delTime);
        Destroy(gameObject);
    }
}
