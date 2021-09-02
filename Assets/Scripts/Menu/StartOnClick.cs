using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnClick : MonoBehaviour
{
    public void StartLevel () 
    {
        Level_Loader.instance.SetCurrentScene(1);

        GameStats.time = Time.time;
    }
}