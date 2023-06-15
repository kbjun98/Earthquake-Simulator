using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamage : MonoBehaviour
{
    private bool isSmoked = false;
    private GameObject EventCheck;
    private AudioSource sound_cough;

    private bool isWatered;

    private void Awake()
    {
        EventCheck = GameObject.Find("EventCheck");
        sound_cough = GameObject.Find("Sound_cough").GetComponent<AudioSource>();
        isWatered = GameObject.Find("playerCam").GetComponent<ObjectInteraction>().isWatered;
    }

    // 플레이어 연기 구역 진입 시 데미지 + 사운드
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("into Smoke");
            var playerCam = other.transform.Find("playerCam").gameObject;
            if (playerCam.GetComponent<ObjectInteraction>().isWatered == false)
            {
                if(EventCheck.GetComponent<EventCheck>().isBurning)
                {
                    isSmoked = true;
                    other.gameObject.GetComponent<PlayerHealth>().smokeDamage += 3.0f;
                    sound_cough.enabled = true;
                }

            }

        }
    }

    // Check if player used watered towel when moving through fire
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(isWatered && Input.GetKeyDown(KeyCode.C))
            {
                EventCheck.GetComponent<EventCheck>().used_towel = true;
            }

        }
    }

    // 플레이어 연기 구역 벗어날 시 데미지 무효화 + 사운드 해제
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("getting out");
            if (isSmoked)
            {
                other.gameObject.GetComponent<PlayerHealth>().smokeDamage = 0.0f;
                isSmoked = false;
                sound_cough.enabled = false;
            }

        }
    }
}
