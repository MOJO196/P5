using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_5_SpawnPoint : MonoBehaviour
{
    public float speed = 5f;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime)*new Vector2 (1,0)+new Vector2(0,transform.position.y);
    }
}
