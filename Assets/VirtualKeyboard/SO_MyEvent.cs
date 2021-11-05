using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MyEvent", menuName = "MyEvent", order = 53)]
public class SO_MyEvent : ScriptableObject
{
    private List<MyEventListener> listeners = new List<MyEventListener>();

    public void Trigger()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    public void RegisterListener(MyEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(MyEventListener listener)
    {
        listeners.Remove(listener);
    }
}
