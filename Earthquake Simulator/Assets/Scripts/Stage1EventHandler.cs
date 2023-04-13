using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1EventHandler : MonoBehaviour
{

    private bool menuOpen = false;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(!menuOpen)
            {
                menuOpen = true;
                PauseMenu.SetActive(true);
            }
            else if(menuOpen)
            {
                menuOpen = false;
                PauseMenu.SetActive(false);
            }
        }
    }
}
