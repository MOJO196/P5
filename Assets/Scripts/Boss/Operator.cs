using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public static Operator instance;
    public float speed = 5f;
    public float damage = 1f;
    public float health = 2f;
    public int size = 50;
    int destroyTime = 1;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (Boss_2.instance.health <= 5)
        {
            StartCoroutine(Delete(destroyTime*7));
        }
        else
        {
            StartCoroutine(Delete(destroyTime*5));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(target.position.x - transform.position.x >= 0)
        {
            transform.localScale = new Vector2 (size, size);
        }
        else
        {
            transform.localScale = new Vector2 (-size, size);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController.instance.ApplyDamage(damage);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController.instance.ApplyDamage(damage);
        }
    }

    IEnumerator Delete (int delTime)
    {
        yield return new WaitForSeconds(delTime);
        Destroy(gameObject);
    }
}
