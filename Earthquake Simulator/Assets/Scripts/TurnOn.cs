using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public GameObject flashLight;
    private bool turnOn;
    public const float lightFog = 0.15f;

    void Awake()
    {
        turnOn= false;
        flashLight.SetActive(turnOn);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            use();
        }
    }
    private void use()
    {
        turnOn = !turnOn;
        flashLight.SetActive(turnOn);
        if(GameManager.hardMode)
        {
            if(turnOn)
            {
                RenderSettings.fogDensity = lightFog;
            }
            else
            {
                RenderSettings.fogDensity = GameManager.darkFog;
            }
        }
    }

}
