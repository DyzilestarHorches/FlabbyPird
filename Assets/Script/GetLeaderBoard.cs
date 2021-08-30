using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class GetLeaderBoard : MonoBehaviour
{
    public Text board;
    public GameObject Panel;

    private void Awake()
    {
        board.text = null;
    }
    public void GetBoard()
    {
        Panel.SetActive(true);
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(request, OnSuccessfulGet, OnError);
    }

    void OnSuccessfulGet(GetLeaderboardResult result)
    {
        foreach( var item in result.Leaderboard)
        {
            board.text += (item.Position + 1).ToString() + " " + item.DisplayName.ToString() + " " + item.StatValue.ToString() + "\n";
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("ErrorLoadLeaderBoard");

    }

    public void Back()
    {
        Panel.SetActive(false);
    }
}
