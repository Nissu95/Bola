using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float time = 0;

    public void Count()
    {
        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }
}
