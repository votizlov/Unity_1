using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class EndgameController : MonoBehaviour
    {
        public GameProxy gameProxy;
        public Text scoreText;

        private void Awake()
        {
            gameProxy.EndGameEvent += OnEndGame;
            gameObject.SetActive(false);
        }

        private void OnEndGame()
        {
            gameObject.SetActive(true);
            scoreText.text = gameProxy.Scores.ToString();
        }
    }
}