﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MyManager : MonoBehaviour {
    public GameObject pauseMenu, scoreboard;
    static public bool isPause = false;
    public bool isTrue;

    private void Start()
    {
        if (isTrue)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        if (isTrue)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                pauseMenu.SetActive(true);
                scoreboard.SetActive(false);
                isPause = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.SetActive(false);
                isPause = false;
            }

            if (Input.GetKeyDown(KeyCode.Tab) && !isPause)
            {
                scoreboard.SetActive(true);
            } 
            else if (Input.GetKeyUp(KeyCode.Tab))
            {
                scoreboard.SetActive(false);
            }

        }
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onResume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        isPause = false;
    }

    public void onHome()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
        isPause = false;
    }

    public void onLoad()
    {
        SceneManager.LoadScene("Castle");
        Time.timeScale = 1;
        isPause = false;
    }
}