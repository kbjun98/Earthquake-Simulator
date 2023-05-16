using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUIManagement : MonoBehaviour
{
    public Image fadeImage;

    public Image CL_escape, CL_elevator, CL_stairs, CL_fire, CL_call, CL_gas, CL_electric, Rank;
    public Sprite O_large, O_small, X_large, X_small, Slash, img_A, img_B, img_C, img_F;
    private Image thisImg;

    private GameObject eventCheck;

    private bool isBurning = false;
    private bool isExtinguished = false;
    private bool isReported = false;

    private bool triggered_valve = false;
    private bool triggered_electric = false;

    private bool escaped_elevator = false;
    private bool escaped_stairs = false;
    private bool escaped_window = false;

    void Awake()
    {
        //eventCheck = GameObject.Find("EventCheck");
        eventCheck = GameObject.Find("EventCheckTest");
        isBurning = eventCheck.GetComponent<EventCheck>().isBurning;
        isExtinguished = eventCheck.GetComponent<EventCheck>().isExtinguished;
        isReported = eventCheck.GetComponent<EventCheck>().isReported;
        triggered_valve = eventCheck.GetComponent<EventCheck>().triggered_valve;
        triggered_electric = eventCheck.GetComponent<EventCheck>().triggered_electric;
        escaped_elevator = eventCheck.GetComponent<EventCheck>().escaped_elevator;
        escaped_stairs = eventCheck.GetComponent<EventCheck>().escaped_stairs;
        escaped_window = eventCheck.GetComponent<EventCheck>().escaped_window;

        CL_escape.enabled = false;
        CL_elevator.enabled = false;
        CL_stairs.enabled = false;
        CL_fire.enabled = false;
        CL_call.enabled = false;
        CL_gas.enabled = false;
        CL_electric.enabled = false;
        Rank.enabled = false;
    }

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    
    void Update()
    {
        
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
            
        }
        else if(!escaped_elevator)
        {
            CL_elevator.GetComponent<Image>().sprite = O_small;
        }

        if(isBurning)
        {
            CL_fire.GetComponent<Image>().sprite = O_large;
            if(isReported)
                CL_fire.GetComponent<Image>().sprite = O_small;
            if(triggered_valve)
                CL_gas.GetComponent<Image>().sprite = O_small;
            if(triggered_electric)
                CL_electric.GetComponent<Image>().sprite = O_small;
        }
        
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
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
        yield return StartCoroutine(ImageFadeIn(Rank));
    }


}
