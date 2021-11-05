using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenKeyboard : MonoBehaviour
{
    private bool isTriggered;
    [SerializeField] private SO_MyEvent openEvent;
    [SerializeField] private SO_Input input;
    void Update()
    {
        if (GetComponent<InputField>().isFocused && !isTriggered)
        {
            openEvent.Trigger();
            input.inputField = GetComponent<InputField>();
            input.input = GetComponent<InputField>().text;
            isTriggered = true;
        }

        if (!GetComponent<InputField>().isFocused)
        {
            isTriggered = false;
        }
    }
}
