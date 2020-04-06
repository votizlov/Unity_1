using Objects;
using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        public GameProxy gameProxy;
        public GameObject[] gameObjects;
        public ExplosionForce explosionForce;
        public CameraShake cameraShake;
        public Timer timer;

        private void OnEnable()
        {
            gameProxy.ExplosionForce = explosionForce;
            gameProxy.CameraShake = cameraShake;
            gameProxy.Timer = timer;
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

            foreach (var o in gameObjects)
            {
                o.SetActive(true);
            }
        }

        private void OnEndGame()
        {
            foreach (var o in gameObjects)
            {
                o.SetActive(false);
            }
        }
    }
}