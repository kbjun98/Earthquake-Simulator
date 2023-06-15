using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockValve : MonoBehaviour
{
    public bool isLocked = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smoot = 1f;

    void Update()
    {
        if (isLocked)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime); 
        }
    }

    public void turnValve()
    {
        isLocked = true;
    }
}
