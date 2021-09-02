using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2_Attack : MonoBehaviour
{
    public static Boss_2_Attack instance;
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

    public Transform firePoint;
	public GameObject operatorPrefab;
    public float delayTime = 5f;
    float time = 0f;
    float newTime;
    bool afterStart;

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
        Instantiate(operatorPrefab, firePoint.position, firePoint.rotation);
    }
}
