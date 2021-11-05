using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Shopping : MonoBehaviour
{
    [SerializeField] private string ItemID;
    [SerializeField] private SO_Item Data;

    public void StartPurchase()
    {
        var request = new StartPurchaseRequest
        {
            Items = new List<ItemPurchaseRequest>
            {
                new ItemPurchaseRequest
                {
                    ItemId = Data.ItemID,
                    Quantity = 1,
                    Annotation = "Purchase via in-game store"
                }
            }
        };//

        PlayFabClientAPI.StartPurchase(request, OnSuccessfullStart, OnError);

    }

    void OnSuccessfullStart(StartPurchaseResult result)
    {
        Debug.Log("Start to call Paypal");
        var request = new PayForPurchaseRequest
        {
            OrderId = result.OrderId,
            Currency = "RM",
            ProviderName = "PayPal"
        };

        PlayFabClientAPI.PayForPurchase(request, OnSuccessfullPay, OnError);
    }

    void OnSuccessfullPay(PayForPurchaseResult result)
    {
        Debug.Log("PaySucceed!");
        Debug.Log(result.PurchaseConfirmationPageURL);
        Debug.Log(result.Status);
        //if (result.Status == TransactionStatus.Succeeded)
            ConfirmPayment(result.OrderId);
    }   
    
    void ConfirmPayment(string ID)
    {
        var request = new ConfirmPurchaseRequest
        {
            OrderId = ID
        };
        PlayFabClientAPI.ConfirmPurchase(request, OnSuccessfullyBuy, OnError);
    }

    void OnSuccessfullyBuy(ConfirmPurchaseResult result)
    {
        Debug.Log("Done!");
    }    
    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
    }
}
