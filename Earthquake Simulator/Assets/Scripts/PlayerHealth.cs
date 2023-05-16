using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHP;
    private float currentHP;

    void Start()
    {
        currentHP= maxHP;
    }

    void Update()
    {
        currentHP-= 1.0f*Time.deltaTime;
    }

    void Damage()
    {

    }

    public float getCurrentHPRatio()
    {
        return currentHP/maxHP;
    }
}
