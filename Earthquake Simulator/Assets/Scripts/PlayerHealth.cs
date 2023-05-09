using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxHP;
    private float currentHP;

    void Start()
    {
        currentHP= maxHP;
    }

    // Update is called once per frame
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
