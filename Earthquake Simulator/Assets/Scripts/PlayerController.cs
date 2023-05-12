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
<<<<<<< HEAD
    public bool optionDisabled = true;
    
    private Item itemEquiped;
    private Inventory inventory;

=======

    private Item itemEquiped;
    private Inventory inventory;
    // Start is called before the first frame update
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inventory= GetComponent<Inventory>();
    }

<<<<<<< HEAD
    void Update()
    {
        Move();
        CharacterRotation();
        ItemEquip();
        
        if (optionDisabled)
            CameraRotation();
=======
    // Update is called once per frame
    void Update()
    {
        Move();
        CameraRotation();
        CharacterRotation();
        ItemEquip();
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
    }

    private void ItemEquip()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0) {
            Debug.Log(wheelInput);
            inventory.changeItem(1);
        }
        else if (wheelInput < 0)
        {
            Debug.Log(wheelInput);
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
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * lookSensitivity;
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

<<<<<<< HEAD
        mainCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX , 0, 0);
=======
        mainCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            inventory.addItem(other.gameObject.GetComponent<Item>());
        }
    }
<<<<<<< HEAD

=======
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
}
