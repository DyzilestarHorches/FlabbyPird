using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public GameObject restartmenu;
    void Update()
    {
        if (GetComponent<GameMove>().isEnd)
        {
            restartmenu.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Resethighscore()
    {
        PlayerPrefs.DeleteAll();
    }
}
