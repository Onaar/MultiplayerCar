using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static bool RACING = false;
    public static int TOTALLAPSTOFINISH = 1;
    public int timer = 3;

    void Start()
    {
        Debug.Log("--------------------------------");
        InvokeRepeating("Countdown", 3, 1);
    }

    void Countdown()
    {
        if (timer != 0)
        {
            Debug.Log("Rozpoczêcie wyœcigu" + timer);
            timer--;
        }
        else
        {
            Debug.Log("Start!");
            RACING = true;
            CancelInvoke("Countdown");
        }
    }
}
