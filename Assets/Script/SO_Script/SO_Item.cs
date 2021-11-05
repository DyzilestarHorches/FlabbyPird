using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 51)]
public class SO_Item : ScriptableObject
{
    [SerializeField] private string itemID;
    public string ItemID
    {
        get
        {
            return itemID;
        }
        set 
        {
            itemID = value;
        }
    }
}
