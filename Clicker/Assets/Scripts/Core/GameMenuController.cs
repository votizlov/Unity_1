using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameMenuController : MonoBehaviour
    {
        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
