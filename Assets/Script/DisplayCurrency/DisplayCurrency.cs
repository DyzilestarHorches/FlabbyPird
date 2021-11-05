using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrency : MonoBehaviour
{
    [SerializeField] private SO_Float currency;
    private void Update()
    {
        this.GetComponent<Text>().text = currency.Value.ToString() + " Gold";
    }
}
