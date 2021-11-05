using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataTransfer : MonoBehaviour
{
    [SerializeField] private SO_Item Data;
    [SerializeField] private string ID;

    public void OnClick()
    {
        Data.ItemID = ID;
    }
}
