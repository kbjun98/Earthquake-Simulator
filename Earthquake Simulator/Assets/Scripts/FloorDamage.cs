using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDamage : MonoBehaviour
{
    private bool isValid = true;
    void Start()
    {
        StartCoroutine(ValidFor3Sec());
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && isValid)
        {
            other.gameObject.GetComponent<PlayerHealth>().getDamage();
            Debug.Log("체력 5 감소");
            //EventSystem.GetComponent<EventManager>().GameOver();
        }
    }



    IEnumerator ValidFor3Sec()
    {
        yield return new WaitForSeconds(2.1f);
        isValid = false;
    }
}
