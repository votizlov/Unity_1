using System;
using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Game Proxy")]
    public class GameProxy : ScriptableObject
    {
        public event Action NewGameEvent;
        public event Action EndGameEvent;
        public event Action<int> AddScoreEvent;
        public event Action<float> TimerTickEvent;
        public event Action TimerEndEvent;
        public event Action TimerAddEvent;
        public ExplosionForce ExplosionForce { get; set; }

        public int Scores { get; private set; }

        public CameraShake CameraShake { get; set; }

        public Timer Timer { get; set; }

        private List<GameObject> _objects = new List<GameObject>();

        public void ClearState()
        {
            Scores = 0;
        }

        public void AddObject(GameObject obj)
        {
            _objects.Add(obj);
        }

        public void RemoveObject(GameObject obj)
        {
            _objects.Remove(obj);
        }

        public void AddScore(int value)
        {
            Scores += value;

            if (Scores > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", Scores);
                PlayerPrefs.Save();
            }

            AddScoreEvent?.Invoke(value);
        }

        public void AddTime(int val)
        {
            Timer.AddTime(val);
            TimerAddEvent?.Invoke();
        }

        public void ShakeCam()
        {
            CameraShake.Shake();
        }

        public void NewGame()
        {
            Physics2D.autoSimulation = true;
            Scores = 0;
            NewGameEvent?.Invoke();
        }

        public void EndGame()
        {
            Physics2D.autoSimulation = false;

            EndGameEvent?.Invoke();
        }

        public void OnTimerTick(float f)
        {
            TimerTickEvent?.Invoke(f);
        }

        public void OnTimerEnd()
        {
            TimerEndEvent?.Invoke();
        }
    }
}