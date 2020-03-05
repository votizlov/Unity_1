using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreController : Action
{
    private TMP_Text _score;
    private int _n = 0;

    private void Start()
    {
        _score = GetComponent<TMP_Text>();
    }

    public override bool ExecuteAction(GameObject otherObject)
    {
        _score.text = (++_n).ToString();
        return true;
    }
}