using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameplayHUD : MonoBehaviour
{
    public GameProxy GameProxy;
    public TMP_Text ScoreText;
    public TMP_Text TimerText;
    public GameObject endButton;

    private void Awake()
    {
        GameProxy.NewGameEvent += OnNewGame;
        GameProxy.AddScoreEvent += OnScoreAdded;
        GameProxy.EndGameEvent += OnEndGame;
        GameProxy.TimerEndEvent += TimerEndEvent;
        GameProxy.TimerTickEvent += TimerTickEvent;
    }

    private void OnDestroy()
    {
        GameProxy.NewGameEvent -= OnNewGame;
        GameProxy.AddScoreEvent -= OnScoreAdded;
        GameProxy.EndGameEvent -= OnEndGame;
        GameProxy.TimerTickEvent -= TimerTickEvent;
        GameProxy.TimerEndEvent += TimerEndEvent;
    }

    private void OnEndGame()
    {
        endButton.SetActive(true);
    }

    private void OnScoreAdded(int delta)
    {
        ScoreText.text = GameProxy.Scores.ToString();
    }

    private void OnNewGame()
    {
        gameObject.SetActive(true);
        ScoreText.text = "0";
    }

    private void TimerEndEvent()
    {
        GameProxy.EndGame();
    }

    private void TimerTickEvent(float t)
    {
        TimerText.text = t.ToString(CultureInfo.InvariantCulture);
    }
}