using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : MonoBehaviour
{
    private GameObject playerCam;
    public Vector3 objPos;
    private GameObject EventCheck;
    private Inventory inventory;
    
    private bool isPlayer = false;

    void Awake()
    {
        playerCam = GameObject.Find("playerCam");
        inventory = playerCam.transform.parent.GetComponent<Inventory>();
        objPos = gameObject.transform.position;
    }

    void Start()
    {
        EventCheck = GameObject.Find("EventCheck");
        StartCoroutine(DetectPlayer(objPos, 4f));
    }

    void Update()
    {
        if (isPlayer)
        {
            gameObject.GetComponent<ObjectOutline>().enabled = true;  
            if(gameObject.name == "Cellphone")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("119 reported");
                    EventCheck.GetComponent<EventCheck>().isReported = true;
                    gameObject.GetComponent<AudioSource>().enabled = true;
                }
            }
            if(gameObject.name == "Towel")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("get towel");
                    playerCam.GetComponent<ObjectInteraction>().haveTowel = true;
                    Destroy(gameObject);
                    inventory.addItem(gameObject.GetComponent<Item>());
                }
            }
        }
        else
        {
            gameObject.GetComponent<ObjectOutline>().enabled = false;
            isPlayer = false;
        }
    }


    IEnumerator DetectPlayer(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;

        while (i < hitColliders.Length) 
        {
            if (hitColliders[i].transform.tag == "Player")
            {
                isPlayer = true;
                break;
            }
            i++;
            isPlayer = false;
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(DetectPlayer(objPos, 4f));
        
    }
}
