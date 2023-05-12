using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
<<<<<<< HEAD
=======
    // Start is called before the first frame update
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa

    public float maxHP;
    private float currentHP;

    void Start()
    {
        currentHP= maxHP;
    }

<<<<<<< HEAD
=======
    // Update is called once per frame
>>>>>>> cb3dcd3490ef5f8543a027c058185c7ba7a7f6aa
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
