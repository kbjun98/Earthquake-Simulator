using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject playerCam, freeCam, player;
    bool isPause;
    int check;

    void Start()
    {
        freeCam.GetComponent<Camera>().enabled = false;
        freeCam.GetComponent<AudioListener>().enabled = false;
        playerCam.GetComponent<Camera>().enabled = true;
        isPause = false;
        check = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            playerCamOn();
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            freeCamOn();
        else{}

        
    }
    
    private void playerCamOn()
    {
        player.SetActive(true);
        freeCam.GetComponent<Camera>().enabled = false;
        freeCam.GetComponent<AudioListener>().enabled = false;
        playerCam.GetComponent<Camera>().enabled = true;
        playerCam.GetComponent<AudioListener>().enabled = true;
    }
    private void freeCamOn()
    {
        player.SetActive(false);
        playerCam.GetComponent<Camera>().enabled = false;
        playerCam.GetComponent<AudioListener>().enabled = false;
        freeCam.GetComponent<Camera>().enabled = true;
        freeCam.GetComponent<AudioListener>().enabled = true;
    }
}
