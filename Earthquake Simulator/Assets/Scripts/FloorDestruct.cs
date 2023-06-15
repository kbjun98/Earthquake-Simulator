using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//천장 오브젝트의 플레이어 접근 감지 & 천장 파괴 스크립트.
public class FloorDestruct : MonoBehaviour
{
    public bool isDestructed = false;
    public bool isSevere = false;
    
    private Vector3 spawnPos, newSpawnPos, newDustPos;

    private GameObject EQManager;
    public GameObject debrisPrefab;
    public GameObject dustPrefab;
    
    void Awake()
    {
        spawnPos = gameObject.transform.position;

        // Debris 종류에 따라 스폰 위치 다르게. 절대좌표계로 오브젝트 소환하는 방법을 잘 모르겠음...
        switch(debrisPrefab.name)
        {
            case "Debris_1" : 
            {
                newSpawnPos = new Vector3(gameObject.transform.position.x-1.7f, gameObject.transform.position.y+0.1f,gameObject.transform.position.z+1.85f);
                newDustPos = newSpawnPos;
                break;
            }
                
            case "Debris_2" :
            {
                newSpawnPos = new Vector3(gameObject.transform.position.x-0.1f, gameObject.transform.position.y+0.1f,gameObject.transform.position.z+0.15f);
                newDustPos = new Vector3(gameObject.transform.position.x-4.1f, gameObject.transform.position.y+0.1f,gameObject.transform.position.z+5.15f);
                break;
            }
                
            case "Debris_3" :
            {
                newSpawnPos = new Vector3(gameObject.transform.position.x-8.7f, gameObject.transform.position.y+1.1f,gameObject.transform.position.z+1.65f);
                newDustPos = new Vector3(gameObject.transform.position.x-5.7f, gameObject.transform.position.y+1.1f,gameObject.transform.position.z+1.65f);
                break;
            }
                
        }
        
        EQManager = GameObject.Find("EarthquakeManager");
    }

    void Start()
    {
        //StartCoroutine(DetectPlayer(spawnPos, 4f));
        StartCoroutine(Waitfor10Sec());
    }

    void Update()
    {
        isSevere = EQManager.GetComponent<EarthquakeManager>().Severe;  // 강진 상태인지 판별
    }

    // 플레이어 감지 후 파괴함수 실행
    IEnumerator DetectPlayer(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        int random_count;

        if (!isSevere)
            random_count = Random.Range(1,5);
        else
            random_count = Random.Range(1,80);

        while (i < hitColliders.Length) 
        {
            if (hitColliders[i].transform.tag == "Player" && random_count < 5)
            {
                Debug.Log("Player detected " + random_count);
                isDestructed = true;
                DestructFloor();
            }
            //Debug.Log(random_count);
            //Debug.Log(isSevere);
            i++;
        }
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(DetectPlayer(spawnPos, 4f));
    }

    // 천장 파괴
    void DestructFloor()
    {
        if(isDestructed)
        {
            gameObject.SetActive(false);
            Instantiate(debrisPrefab, newSpawnPos, Quaternion.identity);
            Instantiate(dustPrefab, newDustPos, Quaternion.identity);
        }
    }

    IEnumerator Waitfor10Sec()
    {
        yield return new WaitForSeconds(12f);
        StartCoroutine(DetectPlayer(spawnPos, 4f));

    }
}
