using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Core;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameProxy GameProxy;
    public float timeLeft = 100;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameProxy.OnTimerEnd();
            Destroy(gameObject);
        }
        else
            GameProxy.OnTimerTick(timeLeft);
    }
}