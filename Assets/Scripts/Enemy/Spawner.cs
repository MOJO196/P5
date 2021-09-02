using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
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

    // Update is called once per frame
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
        Instantiate(operatorPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
