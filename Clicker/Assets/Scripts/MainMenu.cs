using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        GameObject.Find("Score").GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}