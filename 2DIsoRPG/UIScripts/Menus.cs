using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    bool inventorydisplay;
    bool characterdisplay;
    bool mainmenu;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            inventorydisplay = !inventorydisplay;
            GameObject.Find("UserInterface").transform.GetChild(0).gameObject.SetActive(inventorydisplay);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            characterdisplay = !characterdisplay;
            GameObject.Find("UserInterface").transform.GetChild(1).gameObject.SetActive(characterdisplay);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainmenu = !mainmenu;
            GameObject.Find("UserInterface").transform.GetChild(2).gameObject.SetActive(mainmenu);
        }
    }
}
