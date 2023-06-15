using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("TRIGGER");
        if(collision.collider.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Fire damage");
            gameObject.GetComponent<PlayerHealth>().fireDamage = 3.0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        gameObject.GetComponent<PlayerHealth>().fireDamage = 0f;
    }
}
