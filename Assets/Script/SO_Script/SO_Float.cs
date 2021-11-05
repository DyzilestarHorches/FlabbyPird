using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFloat", menuName = "SO_Float", order =52)]
public class SO_Float : ScriptableObject
{
    private float valuE;
    public float Value
    {
        get { return valuE; }
        set { valuE = value; }
    }
}
