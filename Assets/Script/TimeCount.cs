using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class TimeCount : MonoBehaviour
{
    private float time;
    private GameObject GM;

    private void Awake()
    {
        GM = GameObject.Find("GameMaster");
        GetData();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (GM.GetComponent<GameMove>().isEnd) UpdateData();
    }

    void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnSuccess, OnError);
    }

    private void UpdateData()
    {
        var request = new UpdateUserDataRequest()
        {
            Data =  new Dictionary<string, string>
            {

            }
        };
    }

    void OnSuccess(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("TimePlayed"))
            time = float.Parse(result.Data["TimePlayed"].Value);
        else
            Debug.Log("Data Loaded but Info not found!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error Loading");
        Debug.Log(error.ErrorMessage);
    }
}
