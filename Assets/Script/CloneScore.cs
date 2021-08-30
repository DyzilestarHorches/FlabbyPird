using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneScore : MonoBehaviour
{
    public Text score;
    void Update()
    {
        this.GetComponent<Text>().text = score.text;
    }
}
