using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTime : MonoBehaviour
{
    public static FinalTime instance;
    public TextMeshProUGUI text;
    public float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {   
            instance = this;
        }

        finalTime = Time.time-GameStats.time;

        text.text = "Time - "+finalTime.ToString("F2");
    }
}
