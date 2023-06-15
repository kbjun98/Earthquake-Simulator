using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Firstlook : MonoBehaviour
{
    private float time;
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        Invoke("teleport", 10.0f);
    }

    void Update()
    {
        time+=Time.deltaTime;
    }
    private void teleport()
    {
        player.transform.position = new Vector3(-4.5f, 2.7f, 0.4f);
        Debug.Log("TELEPORT");
    }

}
