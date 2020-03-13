using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Core
{
    public class MainMenuController : MonoBehaviour
    {
        public GameProxy gameProxy;
        public TMP_Text highscore;

        public void OnNewGameClick()
        {
            gameProxy.NewGame();
            SceneManager.LoadScene("Game");
        }

        private void Start()
        {
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}