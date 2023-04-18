using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        print("1 "+scene.name);
        nameCheck();
    }

    void Update()
    {
        //Debug.Log(scene.name);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("GameSelect");
        }
    }

    public bool nameCheck()
    {
       Debug.Log(scene.name);
        if(scene.name == "GameTitle")
        {
            print("true");
            return true;
        }
            
        else return false;
        //print(scene.name);
        //string scene_name = scene.name;
        //return scene_name;
    }
}
