using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUIManagement : MonoBehaviour
{
    public Image fadeImage;

    public Image CL_escape, CL_elevator, CL_stairs, CL_fire, CL_call, CL_gas, CL_electric, CL_towel, Image_log, Rank_A, Rank_B, Rank_C;
    public Sprite O_large, O_small, X_large, X_small, Slash;
    private Image thisImg;
    private int count = 0;

    private GameObject eventCheck, eventSystem;

    private bool isBurning = false;
    private bool isExtinguished = false;
    private bool isReported = false;

    private bool triggered_valve = false;
    private bool triggered_electric = false;

    private bool escaped_elevator = false;
    private bool escaped_stairs = false;
    private bool escaped_window = false;
    private bool used_towel = false;

    void Awake()
    {
        eventCheck = GameObject.Find("EventCheck");
        eventSystem = GameObject.Find("EventSystem");
        isBurning = eventCheck.GetComponent<EventCheck>().isBurning;
        isExtinguished = eventCheck.GetComponent<EventCheck>().isExtinguished;
        isReported = eventCheck.GetComponent<EventCheck>().isReported;
        triggered_valve = eventCheck.GetComponent<EventCheck>().triggered_valve;
        triggered_electric = eventCheck.GetComponent<EventCheck>().triggered_electric;
        escaped_elevator = eventCheck.GetComponent<EventCheck>().escaped_elevator;
        escaped_stairs = eventCheck.GetComponent<EventCheck>().escaped_stairs;
        escaped_window = eventCheck.GetComponent<EventCheck>().escaped_window;
        used_towel = eventCheck.GetComponent<EventCheck>().used_towel;

        CL_escape.enabled = false;
        CL_elevator.enabled = false;
        CL_stairs.enabled = false;
        CL_fire.enabled = false;
        CL_call.enabled = false;
        CL_gas.enabled = false;
        CL_electric.enabled = false;
        Image_log.enabled = false;
        //CL_towel.enabled = false;
        Rank_A.enabled = false;
        Rank_B.enabled = false;
        Rank_C.enabled = false;
    }

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    public void OnResultQuitClick()
    {
        // 테스트 목적으로 임시 주석처리.
        //var sound = GameObject.Find("Sound_click").GetComponent<AudioSource>();
        //sound.Play();
        SceneManager.LoadScene("GameSelect");
    }

    public void ResultImageChange()
    {
        if(escaped_stairs)
        {
            CL_escape.GetComponent<Image>().sprite = O_large;
            CL_elevator.GetComponent<Image>().sprite = O_small;
            CL_stairs.GetComponent<Image>().sprite = O_small;
            count++;

        }
        else if(!escaped_elevator)
        {
            CL_elevator.GetComponent<Image>().sprite = O_small;
        }

        if(isBurning)
        {
            CL_fire.GetComponent<Image>().sprite = O_large;
            if(isReported)
            {
                CL_fire.GetComponent<Image>().sprite = O_small;
            }
            if(triggered_valve)
            {
                CL_gas.GetComponent<Image>().sprite = O_small;
                count++;
            }
            if(triggered_electric)
            {
                CL_electric.GetComponent<Image>().sprite = O_small;
                count++;
            }
                
        }
        if(isReported)
        {
            CL_call.GetComponent<Image>().sprite = O_small;
            count++;
        }
        if(triggered_electric)
        {
            CL_electric.GetComponent<Image>().sprite = O_small;
        }
        if(triggered_valve)
        {
            CL_gas.GetComponent<Image>().sprite = O_small;
        }
        if(used_towel)
        {
            //CL_towel.GetComponent<Image>().sprite = O_small;
        }


    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.0f);
        eventSystem.GetComponent<AudioSource>().enabled = true;
        fadeImage.enabled= true;
        float fadeVal = 1;
        while(fadeVal > 0)
        {
            fadeVal -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0,0,0,fadeVal);
        }
        fadeImage.enabled = false;
        ResultImageChange();
        StartCoroutine(ShowResult());
    }

    IEnumerator ImageFadeIn(Image image)
    {
        image.enabled= true;
        float fadeVal = 0;
        while(fadeVal < 1.0f)
        {
            fadeVal += 0.05f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(255,255,255,fadeVal);
        }
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator ShowResult()
    {
        yield return StartCoroutine(ImageFadeIn(CL_escape));
        yield return StartCoroutine(ImageFadeIn(CL_elevator));
        yield return StartCoroutine(ImageFadeIn(CL_stairs));
        yield return StartCoroutine(ImageFadeIn(CL_fire));
        yield return StartCoroutine(ImageFadeIn(CL_call));
        yield return StartCoroutine(ImageFadeIn(CL_gas));
        yield return StartCoroutine(ImageFadeIn(CL_electric));
        //yield return StartCoroutine(ImageFadeIn(CL_towel));
        yield return StartCoroutine(ImageFadeIn(Image_log));

        if(count >= 4)
        {
            yield return StartCoroutine(ImageFadeIn(Rank_A));

        }
        else if (count >= 2)
        {
            yield return StartCoroutine(ImageFadeIn(Rank_B));

        }
        else
        {
            yield return StartCoroutine(ImageFadeIn(Rank_C));
        }
        
    }


}
