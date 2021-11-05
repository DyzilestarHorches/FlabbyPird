using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class GetCurrency : MonoBehaviour
{
    [SerializeField] private SO_Float currency;
    private void Awake()
    {
        var request = new GetUserInventoryRequest();

        PlayFabClientAPI.GetUserInventory(request, OnSuccessfullGet, OnError);
    }

    void OnSuccessfullGet(GetUserInventoryResult result)
    {
        currency.Value = (float)result.VirtualCurrency["GD"];
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
    }
}
