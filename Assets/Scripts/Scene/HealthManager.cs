using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            {   
                instance = this;
            }
    }
    // Update is called once per frame
    void Update()
    {
        text.text = GameStats.lifes.ToString()+"/"+GameStats.health.ToString();
    }
}
