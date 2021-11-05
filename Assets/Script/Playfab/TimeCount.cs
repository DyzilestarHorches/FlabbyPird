using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    private float time;
    private int timeInMinute;
    private GameObject GM;
    private Text timePlayed;

    private void Awake()
    {
        GM = GameObject.Find("GameMaster");
        GetData();
        time = timeInMinute * 60;
    }

    private void Start()
    {
        timePlayed = GameObject.Find("Canvas").transform.GetChild(2).GetChild(5).GetComponent<Text>();    
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (GM.GetComponent<GameMove>().isEnd)
        {
            timePlayed.text = timeInMinute.ToString() + " Minutes Played";
            UpdateData();
        }
    }

    void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnSuccessGet, OnError);
    }

    private void UpdateData()
    {
        timeInMinute += (int)Mathf.Floor(time / 60);
        var request = new UpdateUserDataRequest()
        {
            Data =  new Dictionary<string, string>
            {
                {"TimePlayed", timeInMinute.ToString() }
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnSuccessUpdate, OnError);
    }

    void OnSuccessGet(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("TimePlayed"))
            timeInMinute = int.Parse(result.Data["TimePlayed"].Value);
        else
            Debug.Log("Data Loaded but Info not found!");
    }

    void OnSuccessUpdate(UpdateUserDataResult result)
    {
        Debug.Log("Data Updated!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error Loading");
        Debug.Log(error.ErrorMessage);
    }
}
