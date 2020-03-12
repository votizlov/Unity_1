using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public int score = 10;
    public int clicksToDestroy = 1;
    public GameProxy gameProxy;
    [Header("Scale per frame")] public float k = 1.0001f;
    [Header("Scale k when destroyed")] public float kDestroy = 2;
    private bool _isFreezed = false;

    private void OnEnable()
    {
        gameProxy.AddObject(gameObject);
        gameProxy.TimerEndEvent += Freeze;
    }

    private void OnDisable()
    {
        gameProxy.RemoveObject(gameObject);
    }

    private void Update()
    {
        if (!_isFreezed)
        {
            gameObject.transform.localScale *= k;
            if (gameObject.transform.localScale.x > kDestroy)
                Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!_isFreezed)
        {
            clicksToDestroy--;
            if (clicksToDestroy <= 0)
            {
                gameProxy.AddScore(score);
                Destroy(gameObject);
            }
        }
    }

    private void Freeze()
    {
        _isFreezed = !_isFreezed;
    }
}