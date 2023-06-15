using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Event_fire : MonoBehaviour
{
    private GameObject EventCheck;

    private GameObject fire_inside, fire_outside, fire_insideV2;
    private float time;
    private int random_inside, random_outside;

    void Awake()
    {
        EventCheck = GameObject.Find("EventCheck");
        fire_inside = GameObject.Find("Event_Fire_inside");
        fire_outside = GameObject.Find("Event_Fire_outside");
        fire_insideV2 = GameObject.Find("Event_Fire_insideV2");         // temp
    }
    void Start()
    {
        fire_inside.SetActive(false);
        fire_outside.SetActive(false);
        random_inside = Random.Range(10,100);
        random_outside = Random.Range(10,100);
        Debug.Log("실내 화재변수 : " + random_inside);
        Debug.Log("실외 화재변수 : " + random_outside);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 11)   // 기본값 : 60 + 10초. 테스트 목적으로 5초로 설정함
        {
            if (random_inside > 1)          // test value
            {
                //Debug.Log("실내 화재발생");
                fire_inside.SetActive(true);
                EventCheck.GetComponent<EventCheck>().isBurning = true;      // 실외 불은 끌 필요 없으므로 체크 X
            }

            if (random_outside > 1)            // 복도의 불은 꼭 끌 필요는 없음
            {
                //Debug.Log("실외 화재발생");
                fire_outside.SetActive(true);
            }
        }
    }
}
