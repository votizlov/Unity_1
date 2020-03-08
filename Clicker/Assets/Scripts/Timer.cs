using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : Condition
{
    public float time;
    private TMP_Text _timeText;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.autoSimulation = true;
        _timeText = GetComponent<TMP_Text>();
        _timeText.text = (time).ToString();
        Invoke("_tick", 1f);
    }

    private void _tick()
    {
        _timeText.text = (--time).ToString();
        if (time <= 0.0f)
        {
            ExecuteAllActions(null);
            Physics2D.autoSimulation = false;
            GameObject[] baloons = GameObject.FindGameObjectsWithTag("Baloon");
            foreach (var v in baloons)
            {
                v.GetComponent<ObjectScale>().enabled = false;
                v.GetComponent<ConditionClick>().SetEnabled(false);
            }
        }
        else
            Invoke("_tick", 1f);
    }
}