using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    private void Awake()
    {
        shop.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }
}
