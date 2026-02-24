using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public GameObject pausemenu;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f; 
        paused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("StartMenu");     
    }

    public void Quit()
    {
        Application.Quit();
    }
}
