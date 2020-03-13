using System.Globalization;
using TMPro;
using UnityEngine;

namespace Core
{
    public class GameplayHUD : MonoBehaviour
    {
        public GameProxy gameProxy;
        public TMP_Text scoreText;
        public TMP_Text timerText;
        public GameObject endButton;

        private void Awake()
        {
            gameProxy.NewGameEvent += OnNewGame;
            gameProxy.AddScoreEvent += OnScoreAdded;
            gameProxy.EndGameEvent += OnEndGame;
            gameProxy.TimerEndEvent += TimerEndEvent;
            gameProxy.TimerTickEvent += TimerTickEvent;
        }

        private void OnDestroy()
        {
            gameProxy.NewGameEvent -= OnNewGame;
            gameProxy.AddScoreEvent -= OnScoreAdded;
            gameProxy.EndGameEvent -= OnEndGame;
            gameProxy.TimerTickEvent -= TimerTickEvent;
            gameProxy.TimerEndEvent += TimerEndEvent;
        }

        private void OnEndGame()
        {
            endButton.SetActive(true);
        }

        private void OnScoreAdded(int delta)
        {
            scoreText.text = gameProxy.Scores.ToString();
        }

        private void OnNewGame()
        {
            gameObject.SetActive(true);
            scoreText.text = "0";
        }

        private void TimerEndEvent()
        {
            gameProxy.EndGame();
        }

        private void TimerTickEvent(float t)
        {
            timerText.text = t.ToString(CultureInfo.InvariantCulture);
        }
    }
}