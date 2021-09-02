using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_5_Attack : MonoBehaviour
{
    public static Boss_5_Attack instance;
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

    public Transform spawnPoint;
	public GameObject operatorPrefab;
    public float delayTime = 2f;
    float time = 0f;
    float newTime;
    bool afterStart;
    public bool v2;

    // Start is called before the first frame update
    void Start()
    {
        newTime = Time.time;
        StartCoroutine(AfterStart());
    }

    void Update()
    {
        time = Time.time - newTime;
        
        if(time >= delayTime && afterStart)
        {
            Attack();
            newTime+=delayTime;
            time = 0f;   
        }
    }

    IEnumerator AfterStart ()
    {
        yield return new WaitForEndOfFrame();
        afterStart = true;
        Attack();
    }

    public void Attack ()
    {
        if(v2)
        {
            Instantiate(operatorPrefab, spawnPoint.position, spawnPoint.rotation);
        }   
    }
}
