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
        public GameObject timeAddedPrefab;
        public GameObject UI;

        private void Awake()
        {
            gameProxy.NewGameEvent += OnNewGame;
            gameProxy.AddScoreEvent += OnScoreAdded;
            gameProxy.EndGameEvent += OnEndGame;
            gameProxy.TimerEndEvent += TimerEndEvent;
            gameProxy.TimerTickEvent += TimerTickEvent;
            gameProxy.TimerAddEvent += OnTimerAdd;
        }

        private void OnDestroy()
        {
            gameProxy.NewGameEvent -= OnNewGame;
            gameProxy.AddScoreEvent -= OnScoreAdded;
            gameProxy.EndGameEvent -= OnEndGame;
            gameProxy.TimerTickEvent -= TimerTickEvent;
            gameProxy.TimerEndEvent -= TimerEndEvent;
            gameProxy.TimerAddEvent -= OnTimerAdd;
        }

        private void OnEndGame()
        {
            endButton.SetActive(true);
        }

        private void OnScoreAdded(int delta)
        {
            scoreText.text = gameProxy.Scores.ToString();
            gameProxy.ShakeCam();
        }

        private void OnTimerAdd()
        {
            if (Camera.main != null)
            {
                Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pz.z = 0;
                var go = Instantiate<GameObject>(timeAddedPrefab, pz, Quaternion.identity);
                go.transform.parent = UI.transform;
            }
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