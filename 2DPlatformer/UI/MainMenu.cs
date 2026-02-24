using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject mainmenu, settingsmenu;

    private void Start()
    {
        mainmenu = transform.gameObject;
        settingsmenu = transform.parent.GetChild(2).gameObject;
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
