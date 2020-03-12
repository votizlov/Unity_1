using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameProxy GameProxy;
    public TMP_Text highscore;

    public void OnNewGameClick()
    {
        GameProxy.NewGame();
        gameObject.SetActive(false);
        SceneManager.LoadScene("Game");        
    }

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}