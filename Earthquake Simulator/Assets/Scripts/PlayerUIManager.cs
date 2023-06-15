using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    private GameObject EventCheck;
    public PlayerHealth playerHealth;
    //public Image playerHP;
    public Image hpBarImage;
    public Image fadeImage;
    public Image blurImage;
    public GameObject OptionUI;
    public GameObject EarthquakeUI;
    public TextMeshProUGUI timer_10, timer_300;
    //public GameObject player;
    private float time;
    private GameObject EarthquakeManager;
    private bool before10sec = true;
    //private bool after 10sec = false;
    bool isPause = false;

    private AudioSource audioSource;
    public GameObject extinguisher;
    GameObject player;

    void Awake()
    {
        //playerHP.enabled = false;
        blurImage.enabled = false;
        fadeImage.enabled = false;
        OptionUI.SetActive(false);
        timer_10.enabled = false;
        timer_300.enabled = false;
        EarthquakeUI.SetActive(false);
        //playerHealth.enabled = false;

        EventCheck = GameObject.FindWithTag("EventCheck");
        EarthquakeManager = GameObject.Find("EarthquakeManager");
        player = GameObject.Find("Player");
        audioSource = player.GetComponent<AudioSource>();
    }

    void Start()
    {
        //playerHP.enabled = true;
        timer_10.enabled = true;
        
        StartCoroutine(FadeInOut());
        //StartCoroutine(Timer10Sec());
    }

    void Update()
    {

        time += Time.deltaTime;
        timer_10.text = (10 - (int)time).ToString();
        timer_300.text = (313 - (int)time).ToString();
        if (time > 10)
        {
            timer_10.enabled = false;
            before10sec = false;
            //EarthquakeManager.GetComponent<EarthquakeManager>().GameStart();
        }

        //audioSource.Play();
        if (time >= 13 && time<= 14)
        {
            timer_300.enabled = true;
            EarthquakeUI.SetActive(true);
        }
            
        if (time > 314)
        {
            timer_300.enabled = false;
            //eventcheck.GetComponent<EventCheck>().
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            extinguisher.GetComponent<AudioSource>().Stop();
        }


        hpBarImage.fillAmount= Mathf.Clamp(playerHealth.getCurrentHPRatio(),0,1.0f);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            int check = 0;
            if(isPause == false)         // 게임 일시정지됨
            {
                isPause = true;
                blurImage.enabled = true;
                if (before10sec)
                    timer_10.enabled = false;
                if (!before10sec)
                    timer_300.enabled = false;
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
                if (before10sec)
                    timer_10.enabled = true;
                if (!before10sec)
                    timer_300.enabled = true;
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
        audioSource.Play();
        audioSource.loop = true;
    }


}
