using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{
    public GameProxy GameProxy;
    public Timer Timer;
    public GameObject[] GameObjects;

    private void OnEnable()
    {
        GameProxy.NewGameEvent += OnNewGame;
        GameProxy.EndGameEvent += OnEndGame;
    }

    private void OnDisable()
    {
        GameProxy.NewGameEvent -= OnNewGame;
        GameProxy.EndGameEvent -= OnEndGame;
    }

    private void OnNewGame()
    {
        // clear all
        GameProxy.ClearState();

        // enable physics
        Physics2D.autoSimulation = true;

        foreach (var o in GameObjects)
        {
            o.SetActive(true);
        }
    }

    private void OnEndGame()
    {
        foreach (var o in GameObjects)
        {
            o.SetActive(false);
        }
    }
}