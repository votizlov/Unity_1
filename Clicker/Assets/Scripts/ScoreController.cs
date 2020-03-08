using TMPro;
using UnityEngine;

public class ScoreController : Action
{
    private TMP_Text _score;
    private int _n;

    private void Start()
    {
        _score = GetComponent<TMP_Text>();
    }

    public override bool ExecuteAction(GameObject otherObject)
    {
        _score.text = (++_n).ToString();
        if (_n > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", _n);
            PlayerPrefs.Save();
        }

        return true;
    }
}