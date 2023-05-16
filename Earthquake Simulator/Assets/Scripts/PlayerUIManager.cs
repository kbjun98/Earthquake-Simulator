using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image hpBarImage;
    public Image fadeImage;
    public Image blurImage;
    public GameObject OptionUI;

    bool isPause = false;

    GameObject player;

    void Awake()
    {
        blurImage.enabled = false;
        fadeImage.enabled = false;
        OptionUI.SetActive(false);
    }

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(FadeInOut());
    }

    void Update()
    {
        hpBarImage.fillAmount= Mathf.Clamp(playerHealth.getCurrentHPRatio(),0,playerHealth.maxHP);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            int check = 0;
            if(isPause == false)         // 게임 일시정지됨
            {
                isPause = true;
                blurImage.enabled = true;
                Debug.Log(isPause.ToString() + check.ToString());
                check++;
                Time.timeScale = 0;
                player.GetComponent<PlayerController>().optionDisabled = false;
                OptionUI.SetActive(true);
            }
            else                        // 일시정지 해제
            {
                isPause = false;
                blurImage.enabled = false;
                Debug.Log(isPause.ToString() + check.ToString());
                check++;
                Time.timeScale = 1;
                player.GetComponent<PlayerController>().optionDisabled = true;
                OptionUI.SetActive(false);
            }
        }
        else{}
    }

    IEnumerator FadeInOut()
    {
        yield return new WaitForSeconds(7.5f);
        fadeImage.enabled= true;
        float fadeVal = 0;
        while(fadeVal < 1.0f)
        {
            fadeVal += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0,0,0,fadeVal);
        }
        yield return new WaitForSeconds(2.0f);
        while(fadeVal > 0)
        {
            fadeVal -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0,0,0,fadeVal);
        }
    }
}
