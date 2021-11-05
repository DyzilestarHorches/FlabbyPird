using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

public class PlayfabLeaderboard : MonoBehaviour
{
    public void UpdateBoard()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScore",
                    Value = PlayerPrefs.GetInt("highscore")
                }
            }

        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSuccessfulUpdate, OnError);
    }

    void OnSuccessfulUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully Updated Leaderboard!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Failed to Update!");
        Debug.Log(error.GenerateErrorReport());
    }
}
