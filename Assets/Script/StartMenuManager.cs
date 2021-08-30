using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public GameObject leaderboard;
    public void StartGame()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    public void OpenLeaderboard()
    {
        leaderboard.SetActive(true);
        Loadleaderboard();
    }

    void Loadleaderboard()
    {

    }

    public void CloseLeaderboard()
    {
        leaderboard.SetActive(false);
    }
}
