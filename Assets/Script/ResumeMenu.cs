using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool isPause;
    // Start is called before the first frame update

    private void Awake()
    {
        isPause = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenuManage();
    }

    void PauseMenuManage()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
                Pause();
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPause = true;
    }
}
