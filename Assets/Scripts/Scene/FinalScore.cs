using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public static FinalScore instance;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {   
            instance = this;
        }

        text.text = "Score - "+GameStats.score.ToString();
    }
}
