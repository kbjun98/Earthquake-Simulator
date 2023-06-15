using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameObject EventSystem, EventCheck;
    public float maxHP;
    public float currentHP;

    public float fireDamage = 0f;
    public float rockFallDamage = 0f;
    public float fireDefense = 0f;
    public float rockFallDefense = 0f;
    public float smokeDamage = 0f;
    public float smokeDefense = 0f;

    private bool _escape = false;

    void Awake()
    {
        EventSystem = GameObject.Find("EventSystem");
        EventCheck = GameObject.Find("EventCheck");
        currentHP= maxHP;
    }
    void Start()
    {
    }

    void Update()
    {
        currentHP-= (1-fireDefense)*fireDamage*Time.deltaTime;          // Fire damage
        currentHP-= (1-rockFallDefense)*rockFallDamage*Time.deltaTime;  // Rock damage
        currentHP-= (1-smokeDefense)*smokeDamage*Time.deltaTime;        // Smoke damage

        if(currentHP <= 0 && !_escape)
        {
            EventCheck.GetComponent<EventCheck>().HP = 0f;
            EventSystem.GetComponent<EventManager>().GameOver();
            _escape = true;
        }
    }


    public float getCurrentHPRatio()
    {
        return currentHP/maxHP;
    }

    public void setDefense(Item newitem)
    {
        fireDefense = newitem.fireDefense;
        rockFallDefense = newitem.rockFallDefense;
        smokeDefense = newitem.smokeDefense;
    }

    public void getDamage()
    {
        currentHP -= 5.0f;
    }
}
