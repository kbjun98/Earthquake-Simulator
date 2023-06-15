using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event_escape : MonoBehaviour
{
    public GameObject EventCheck;
    public Image fadeImage;
    private GameObject EventSystem, player;

    private void Awake()
    {
      EventSystem = GameObject.Find("EventSystem");
      player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("계단으로 탈출.");
            EventCheck.GetComponent<EventCheck>().escaped_stairs = true;
            EventCheck.GetComponent<EventCheck>().HP = player.GetComponent<PlayerHealth>().currentHP;
            EventSystem.GetComponent<EventManager>().GameOver();
        }
    }
}
