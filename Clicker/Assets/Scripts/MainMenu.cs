using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        GameObject.Find("Score").GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}