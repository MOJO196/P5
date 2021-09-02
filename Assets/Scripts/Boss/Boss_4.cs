using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4 : MonoBehaviour
{
    public static Boss_4 instance;
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
    
    Transform target;
    public bool junior = true;
    public float damage = 1;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!junior)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 5 * Time.deltaTime)*new Vector2 (1,0)+new Vector2(0,transform.position.y);
            anim.SetBool("JuniorAlive", false);
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(junior)
        {
            if(other.CompareTag ("Player"))
            {
                other.SendMessage("ApplyDamage",damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(junior)
        {
            if(other.CompareTag ("Player"))
            {
                other.SendMessage("ApplyDamage",damage);
            }
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Level_Loader.instance.LoadNextLevel();
    }
}
