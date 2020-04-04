using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameProxy gameProxy;

    private void OnEnable()
    {
        gameProxy.TimerEndEvent += Freeze;
    }

    private void Freeze()
    {
        //explosion.Pause();//pause calling stop
    }
}