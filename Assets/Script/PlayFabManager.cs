using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    public InputField email, password, namE;

    public Text message;

    public void Register()
    {

        if (password.text.Length < 6)
        {
            message.text = "Password must contain more than 5 characters";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = password.text,
            Username = namE.text,
            DisplayName = namE.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccessRegister, OnError);
    }

    void OnSuccessRegister(RegisterPlayFabUserResult result)
    {
        message.text = "Successfully Registered and Logged in!";
        SceneManager.LoadScene("StartMenu");
    }    

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = password.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccessLogin, OnError);
    }

    void OnSuccessLogin(LoginResult result)
    {
        Debug.Log("Successfully logged in!");
        SceneManager.LoadScene("StartMenu");
    }

    void OnError(PlayFabError error)
    {
        message.text = error.ErrorMessage;
        Debug.Log("Failed to Login/Register!");
        Debug.Log(error.GenerateErrorReport());
    }
}
