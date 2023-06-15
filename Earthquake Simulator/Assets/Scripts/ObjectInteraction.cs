using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactDiastance = 5f;
    private GameObject EventCheck;
    private GameObject EventSystem;
    public GameObject extinguisher;
    public GameObject Towel;
    
    private Rigidbody rb;
    private Vector3 CameraPos;
    private Inventory inventory;
    //private GameObject temp;

    private bool isHiding = false;
    private bool isCrouched = false;
    public bool isEnabled = false;

    public bool haveTowel = false;      // public for test
    public bool isWatered = false;
    

    void Awake()
    {
        extinguisher.SetActive(false);
        EventCheck = GameObject.Find("EventCheck");
        EventSystem = GameObject.Find("EventSystem");
        inventory = gameObject.transform.parent.GetComponent<Inventory>();
        rb = gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        isEnabled = extinguisher.GetComponent<Extinguisher>().isEnabled;
        CameraPos = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(HeadDown());
        }
        if (isEnabled)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Fire"))
                {
                    //Debug.Log("Before off");
                    StartCoroutine(DestroyFire(hit.collider.gameObject));
                    //Destroy(hit.collider.gameObject);
                    //Debug.Log("fire off");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed E");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.Log("ray casted");
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log("ENTER");
                    hit.collider.transform.parent.GetComponent<DoorOpen>().ChangeDoorState();
                    Debug.Log("Enter2");
                }

                if (hit.collider.CompareTag("Elevator"))
                {
                    EventCheck.GetComponent<EventCheck>().escaped_elevator = true;
                    EventSystem.GetComponent<EventManager>().GameOver();
                }

               

                if (hit.collider.CompareTag("Fuse"))
                {
                    Debug.Log("Fuse off");
                    EventCheck.GetComponent<EventCheck>().triggered_electric = true;
                    hit.collider.GetComponent<AudioSource>().enabled = true;
                    //레버 효과음 추가
                }
                if (hit.collider.CompareTag("Valve"))
                {
                    Debug.Log("Valve off");
                    EventCheck.GetComponent<EventCheck>().triggered_valve = true;
                    hit.collider.transform.parent.GetComponent<LockValve>().turnValve();
                    //밸브 효과음 추가
                }
                if (hit.collider.name == "Cellphone")
                {
                    Debug.Log("119 reported");
                    EventCheck.GetComponent<EventCheck>().isReported = true;
                    hit.collider.GetComponent<AudioSource>().enabled = true;
                }
                if (hit.collider.name == "Table_1" || hit.collider.name == "Table_2")
                {
                    if(!isHiding)
                    {
                        Vector3 tPos = hit.collider.transform.position;

                        StartCoroutine(getDown(tPos));
                        isHiding = true;
                    }

                }
                if (hit.collider.name=="Towel")  // 손수건 획득
                {
                    //Debug.Log("get towel");
                    //haveTowel = true;
                    //Destroy(hit.collider.gameObject);
                    //inventory.addItem(hit.collider.GetComponent<Item>());
                }
                if (hit.collider.name=="Box002(Clone)")  // 손수건 획득
                {
                    Debug.Log("get Pillow");
                    Destroy(hit.collider.gameObject);
                    inventory.addItem(hit.collider.GetComponent<Item>());
                    // 효과음 추가
                }
                if (hit.collider.name == "Water" && haveTowel)
                {
                    Debug.Log("Water");
                    isWatered = true;
                    Towel.GetComponent<ChangeTexture>().changeTexture();
                    hit.collider.GetComponent<AudioSource>().enabled = true;
                }

            }
        }
        if(isHiding)
            StartCoroutine(getUp());

        if (isCrouched)
            StartCoroutine(HeadUp());
    }

    // Hide under desk
    IEnumerator getDown(Vector3 tPos)
    {
        if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Hiding");
                //transform.parent.position = new Vector3(-5.4f, 0.1f, -6.5f);
                transform.parent.position = new Vector3(tPos.x, tPos.y - 2.6f, tPos.z);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                transform.parent.Rotate(0,180,0);
                transform.parent.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
                transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
                transform.parent.gameObject.GetComponent<PlayerController>().speed = 0;
                //숨기 효과음 추가
            }
        yield return null;
    }

    IEnumerator getUp()
    {
        yield return new WaitForSeconds(0.1f);
        if(isHiding && Input.GetKeyDown(KeyCode.E))
        {
            Vector3 pPos = transform.parent.position;
            //transform.parent.position = new Vector3(-4.7f, 2.7f, -0.5f);
            transform.parent.position = new Vector3(pPos.x + 1f, pPos.y+2.6f, pPos.z + 6f);
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            transform.parent.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
            transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
            transform.parent.gameObject.GetComponent<PlayerController>().speed = 20;
            //나오는 효과음 추가
            isHiding = false;
        }
        yield return null;
    }

    IEnumerator HeadUp()
    {
        yield return new WaitForSeconds(0.1f);
        if(isCrouched && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("HeadUP");
            gameObject.transform.position = new Vector3(CameraPos.x, CameraPos.y+2.4f,CameraPos.z);
            isCrouched = false;
        }
        yield return null;
    }

    IEnumerator HeadDown()
    {
        if(!isCrouched && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("HeadDown");
            gameObject.transform.position = new Vector3(CameraPos.x, CameraPos.y-2.4f,CameraPos.z);
            isCrouched = true;
        }
        yield return null;
    }

    IEnumerator DestroyFire(GameObject fire)
    {
        yield return new WaitForSeconds(2f);
        Destroy(fire);
        Debug.Log("fire off");
    }
}
