using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventListener : MonoBehaviour
{
    public SO_MyEvent InputEvent;
    public UnityEvent OutputEvent;

    private void OnEnable()
    {
        InputEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        InputEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        OutputEvent?.Invoke();
    }
}

