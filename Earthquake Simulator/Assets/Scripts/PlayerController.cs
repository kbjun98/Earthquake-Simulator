using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody playerRigidbody;

    public Camera mainCamera;
    public float lookSensitivity;
    private float currentCameraRotationX = 0;

    public float cameraRotationLimit;
    public float jumpForce;
    public bool optionDisabled = true;

    public float xRotation;
    public float yRotation;
    
    private Item itemEquiped;
    private Inventory inventory;

    private AudioSource sound_walk;

    private bool isMoving = false;
    void Awake()
    {
        sound_walk = GameObject.Find("Sound_moving").GetComponent<AudioSource>();
    }
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inventory= GetComponent<Inventory>();
    }

    void Update()
    {
        Move();
        CharacterRotation();
        ItemEquip();
        
        if (optionDisabled)
            CameraRotation();

        if (isMoving)
        {
            sound_walk.enabled = true;
        }
        else
        {
            sound_walk.enabled = false;
        }
    }

    private void useItem()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Item equippedItem = inventory.getEquippedItem();
            equippedItem.Use();
        }
    }

    private void ItemEquip()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0) {
            inventory.changeItem(1);
        }
        else if (wheelInput < 0)
        {
            inventory.changeItem(-1);
        }
    }

    private void CharacterRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotation = new Vector3(0, yRotation, 0) * lookSensitivity;
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(characterRotation));
    }

    private void CameraRotation()
    {
        xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = -xRotation * lookSensitivity;
        mainCamera.transform.Rotate(cameraRotationX, 0, 0);
        Quaternion currentCameraRotation = mainCamera.transform.rotation;

        if (currentCameraRotation.x > cameraRotationLimit) {
            currentCameraRotation.x = cameraRotationLimit;
        }
        else if (currentCameraRotation.x < -cameraRotationLimit)        {
            currentCameraRotation.x = -cameraRotationLimit;
        }
        mainCamera.transform.rotation = currentCameraRotation;
    }

    private void Move()
    {

        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
        playerRigidbody.MovePosition(transform.position + velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up*jumpForce);
        }

        if(velocity == new Vector3(0,0,0))
        {
            //Debug.Log("player stopped");
            isMoving = false;
            //var sound = GameObject.Find("Sound_moving").GetComponent<AudioSource>();
            //sound.Stop();
        }
        else
        {
            //Debug.Log("player moving");
            isMoving = true;
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            inventory.addItem(other.gameObject.GetComponent<Item>());
        }
    }
}
