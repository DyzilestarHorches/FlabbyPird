using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private SO_Input input;
    static private bool isShifted;

    public void OnClick()
    {
        if (!isShifted) input.input += transform.Find("Text").GetComponent<Text>().text;
        else input.input += transform.Find("Text").GetComponent<Text>().text.ToUpper();
    }

    public void OnDone()
    {
        input.inputField.text = input.input;
    }

    public void Shift()
    {
        if (isShifted)
        {
            isShifted = false;
            transform.Find("Text").GetComponent<Text>().text = "caps";
        }
        else
        {
            isShifted = true;
            transform.Find("Text").GetComponent<Text>().text = "CAPS";
        }
    }

    public void Delete()
    {
        if (input.input != null)
            input.input = input.input.Substring(0, input.input.Length - 1);
    }
}
