using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualKeyboard : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text displayInput;
    [SerializeField] private SO_Input input;
    [SerializeField] private Button pf_key;

    private readonly string[] keyNames = { "qwertyuiop", "asdfghjkl", "zxcvbnm@", " " };
    private readonly string[] keyNum = { "123", "456", "789", "0." };

    private void Awake()
    {
        panel.SetActive(false);
    }

    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        displayInput.text = input.input;
    }

    public void LoadKeyboard()
    {
        //if clicked open keyboard
        panel.SetActive(true);
    }

    public void CloseKeyboard()
    {
        panel.SetActive(false);
    }

    void Generate()
    {
        for (int i = 0; i <= 3; i++)
        {
            int j = 0;
            foreach (char c in keyNames[i])
            {
                j++;
                Button a = Instantiate(pf_key, panel.GetComponent<RectTransform>()) as Button;

                a.GetComponent<RectTransform>().anchoredPosition = new Vector2(10 + j * 50, -50 - i * 50);

                a.transform.Find("Text").GetComponent<Text>().text = c.ToString();

                if (c == ' ')
                {
                    a.GetComponent<RectTransform>().sizeDelta += new Vector2(200, 0);
                }
            }
        }

        for (int i = 0; i <= 3; i++)
        {
            int j = 0;
            foreach (char c in keyNum[i])
            {
                j++;
                Button a = Instantiate(pf_key, panel.GetComponent<RectTransform>()) as Button;

                a.GetComponent<RectTransform>().anchoredPosition = new Vector2(600 + j * 50, -50 - i * 50);

                a.transform.Find("Text").GetComponent<Text>().text = c.ToString();
            }
        }

    }

    
}
