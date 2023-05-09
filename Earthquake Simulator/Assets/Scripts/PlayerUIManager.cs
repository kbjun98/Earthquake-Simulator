using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealth playerHealth;
    public Image hpBarImage;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hpBarImage.fillAmount= Mathf.Clamp(playerHealth.getCurrentHPRatio(),0,playerHealth.maxHP);
    }
}
