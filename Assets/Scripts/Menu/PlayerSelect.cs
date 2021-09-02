using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public void Player1()
    {
        GameStats.player = 1;
    }

    public void Player2()
    {
        GameStats.player = 2;
    }

    public void Player3()
    {
        GameStats.player = 3;
    }

    public void Player4()
    {
        GameStats.player = 4;
    }
}
