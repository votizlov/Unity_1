using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;

public class EndgameController : MonoBehaviour
{
    public GameProxy GameProxy;
    public Text ScoreText;

    private void Awake()
    {
        GameProxy.EndGameEvent += OnEndGame;
        gameObject.SetActive(false);
    }

    private void OnEndGame()
    {
        gameObject.SetActive(true);
        ScoreText.text = GameProxy.Scores.ToString();
    }

    public void OnReplayClick()
    {
        gameObject.SetActive(false);
        GameProxy.NewGame();
    }
}