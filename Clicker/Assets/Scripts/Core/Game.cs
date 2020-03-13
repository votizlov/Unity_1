using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        public GameProxy gameProxy;
        public GameObject[] GameObjects;

        private void OnEnable()
        {
            gameProxy.NewGameEvent += OnNewGame;
            gameProxy.EndGameEvent += OnEndGame;
        }

        private void OnDisable()
        {
            gameProxy.NewGameEvent -= OnNewGame;
            gameProxy.EndGameEvent -= OnEndGame;
        }

        private void OnNewGame()
        {
            // clear all
            gameProxy.ClearState();

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
}