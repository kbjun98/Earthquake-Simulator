using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("BURNING1");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("BURNING PLAYER");
            other.gameObject.GetComponent<PlayerHealth>().fireDamage = 8.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("getting out");
            other.gameObject.GetComponent<PlayerHealth>().fireDamage = 0.0f;
        }
    }
}
